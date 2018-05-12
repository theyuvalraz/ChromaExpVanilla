using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChromaExpVanilla.config;
using Interfacer.Interfaces;
using TrayApp.Properties;
using static ChromaExpVanilla.KeyControl;
using CheckState = ChromaExpVanilla.CheckState;
using Timer = System.Windows.Forms.Timer;

namespace TrayApp
{
    public partial class Magic
    {
        private const int CheckInterval = 30;
        private static Timer _t;

        private NotifyIcon _sysTrayIcon;

        private readonly IKeyboardController _control = Instance;
        private readonly KeyBlocks _blocks = new KeyBlocks();

        private string _tooltip = string.Empty;

        private readonly TimeControl _timeControl = new TimeControl();

        private readonly ConcurrentQueue<BackgroundWorker> _backgroundWorkerStack =
            new ConcurrentQueue<BackgroundWorker>();

        public Magic()
        {
            InitializeComponent();
        }

        protected override async void OnLoad(EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;
            var sysTrayMenu = new ContextMenu();
            sysTrayMenu.MenuItems.Add("Restart Indicator", OnRestart);
            sysTrayMenu.MenuItems.Add("Exit", OnExit);

            _sysTrayIcon = new NotifyIcon();
            _tooltip = "Chroma Indicator";
            _sysTrayIcon.Text = _tooltip;
            _sysTrayIcon.Icon = new Icon(Resources.Y, 40, 40);
            _sysTrayIcon.ContextMenu = sysTrayMenu;
            _sysTrayIcon.Visible = true;


            _control.Animation(_blocks.AnimationConcept);
            _control.FrameAnimation(_blocks.AnimationConceptStage2);

            var task = Task.Run(() => _control.CustomLayer.Clear());
            await task.ContinueWith(t => _control.SetColorBase());

            _control.InitiateCustom();

            AddbackgroundWorker();
            _backgroundWorkerStack.TryPeek(out var worker);
            worker.DoWork += BackgroundWorkerOnDoWork;
            worker.ProgressChanged += BackgroundWorkerOnProgressChanged;
            worker.RunWorkerAsync();

            _t = new Timer
            {
                Interval = _timeControl.CalculateTimerInterval(CheckInterval)
            };
            _t.Tick += ActivateTimed_Tick;
            _t.Start();

            base.OnLoad(e);
        }

        private void ActivateTimed_Tick(object sender, EventArgs e)
        {
            _control.TimeAnimation();
            _t.Interval = _timeControl.CalculateTimerInterval(CheckInterval);
        }

        private static void BackgroundWorkerOnDoWork(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker) sender;
            var checkState = new CheckState();

            while (!worker.CancellationPending)
            {
                Thread.Sleep(100);
                var state = checkState.States();
                worker.ReportProgress(state);
            }
            worker.CancelAsync();
        }

        private static void BackgroundWorkerOnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var eventsType = (Action) e.UserState;
            if (eventsType == null) return;
            foreach (var actionDelegate in eventsType.GetInvocationList())
            {
                var lTask = Task.Factory.StartNew(() => actionDelegate.DynamicInvoke());
                lTask.ContinueWith(i => { Console.WriteLine($@"canceled"); },
                    TaskContinuationOptions.OnlyOnCanceled);
                lTask.ContinueWith(i => { Console.WriteLine($@"faulted"); },
                    TaskContinuationOptions.OnlyOnFaulted);
                lTask.ContinueWith(i => { Console.WriteLine($@"completion"); },
                    TaskContinuationOptions.OnlyOnRanToCompletion);
            }
        }

        private void AddbackgroundWorker()
        {
            _backgroundWorkerStack.Enqueue(new BackgroundWorker
                {
                    WorkerReportsProgress = true,
                    WorkerSupportsCancellation = true
                }
            );
        }

        private void RemovebackgroundWorkers()
        {
            _backgroundWorkerStack.TryDequeue(out var result);
            result.CancelAsync();
            result.Dispose();
        }

        private async void OnRestart(object sender, EventArgs e)
        {
            RemovebackgroundWorkers();
            _control.Animation(_blocks.AnimationConcept);

            _control.CustomLayer.Clear();
            await _control.SetColorBase();

            AddbackgroundWorker();
            _backgroundWorkerStack.TryPeek(out BackgroundWorker worker);
            worker.DoWork += BackgroundWorkerOnDoWork;
            worker.ProgressChanged += BackgroundWorkerOnProgressChanged;
            worker.RunWorkerAsync();
            _t.Start();
        }

        private void OnExit(object sender, EventArgs e)
        {
            _sysTrayIcon.Visible = false;
            Application.Exit();
        }
    }

    public static class BackgroundWorkerExt
    {
        public static void ReportProgress(this BackgroundWorker self, Task<Action> state)
        {
            const int dummyProgress = 0;
            self?.ReportProgress(dummyProgress, state?.Result);
        }
    }
}