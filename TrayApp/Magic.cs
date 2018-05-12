using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChromaExpVanilla;
using ChromaExpVanilla.config;
using CheckState = ChromaExpVanilla.CheckState;
using Interfacer.Interfaces;

namespace TrayApp
{
    public partial class Magic
    {
        private const int CheckInterval = 30;
        static System.Windows.Forms.Timer _t;

        private NotifyIcon _sysTrayIcon;

        private readonly IKeyboardController _control = new KeyControl();
        private readonly KeyBlocks _blocks = new KeyBlocks();

        private string _tooltip = string.Empty;

        private readonly TimeControl _timeControl = new TimeControl();

        private readonly ConcurrentQueue<BackgroundWorker> _backgroundWorkerStack =
            new ConcurrentQueue<BackgroundWorker>();


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
            _backgroundWorkerStack.TryDequeue(out BackgroundWorker result);
            result.CancelAsync();
            result.Dispose();
        }

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
            _sysTrayIcon.Icon = new Icon(Properties.Resources.Y, 40, 40);
            _sysTrayIcon.ContextMenu = sysTrayMenu;
            _sysTrayIcon.Visible = true;


            _control.Animation(_blocks.AnimationConcept);
            _control.FrameAnimation(_blocks.AnimationConceptStage2);

            var task = Task.Run(() => _control.CustomLayer.Clear());
            await task.ContinueWith((t) => _control.SetColorBase());

            _control.InitiateCustom();

            AddbackgroundWorker();
            _backgroundWorkerStack.TryPeek(out BackgroundWorker worker);
            worker.DoWork += BackgroundWorkerOnDoWork;
            worker.ProgressChanged += BackgroundWorkerOnProgressChanged;
            worker.RunWorkerAsync();

            _t = new System.Windows.Forms.Timer
            {
                Interval = _timeControl.CalculateTimerInterval(CheckInterval)
            };
            _t.Tick += ActivateTimed_Tick;
            _t.Start();

            base.OnLoad(e);
        }

        private void BackgroundWorkerOnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var eventsType = (Action) e.UserState;

            eventsType?.Invoke();


            //var eventsType = (Task<Action>) e.UserState;
            //Action actionsNeeded = () => { };
            //if (eventsType == null) return;
            //foreach (var distinctEvent in eventsType?.Result?.GetInvocationList()?.Distinct())
            //{
            //    actionsNeeded += (Action) distinctEvent;
            //}
            //actionsNeeded?.Invoke();
        }

        private void BackgroundWorkerOnDoWork(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker) sender;
            IStateChecker checkState = new CheckState();

            while (!worker.CancellationPending)
            {
                Thread.Sleep(100);
                var state = checkState?.States(_control);
                worker.ReportProgress(state);
            }
        }


        private void OnExit(object sender, EventArgs e)
        {
            _sysTrayIcon.Visible = false;
            Application.Exit();
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


        private bool OnDisabled()
        {
            _backgroundWorkerStack.TryPeek(out BackgroundWorker worker);
            {
                worker.CancelAsync();
            }
            ;
            return true;
        }


        private void ActivateTimed_Tick(object sender, EventArgs e)
        {
            _control.TimeAnimation();
            _t.Interval = _timeControl.CalculateTimerInterval(CheckInterval);
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