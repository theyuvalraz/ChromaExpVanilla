using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfacer.Interfaces;
using TrayApp.Properties;
using CheckState = ChromaExpVanilla.CheckState;
using Timer = System.Windows.Forms.Timer;
//using System.Linq;
//using ChromaExpVanilla;
//using ChromaExpVanilla.config;

namespace TrayApp
{
    public partial class Magic
    {
        private const int CheckInterval = 30;
        private static Timer _t;

        private readonly ConcurrentQueue<BackgroundWorker> _backgroundWorkerStack =
            new ConcurrentQueue<BackgroundWorker>();

        private readonly TimeControl _timeControl = new TimeControl();

        private NotifyIcon _sysTrayIcon;

        private string _tooltip = string.Empty;
        private readonly IStateChecker _checkState = new CheckState();

        public Magic()
        {
            InitializeComponent();
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

        protected override void OnLoad(EventArgs e)
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

        private static void BackgroundWorkerOnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var eventsType = (Action) e.UserState;
            eventsType?.Invoke();
        }

        private void BackgroundWorkerOnDoWork(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker) sender;
            _checkState.FirstAnimationNeeded = true;
            _checkState.SecondAnimationNeeded = true;
            _checkState.ClearNeeded = true;
            _checkState.BaseNeeded = true;
            _checkState.CurrentStateNeeded = true;
            while (!worker.CancellationPending)
            {
                Thread.Sleep(100);
                var state = _checkState.States();
                worker.ReportProgress(state);
            }
            worker.CancelAsync();
        }

        private void OnExit(object sender, EventArgs e)
        {
            _sysTrayIcon.Visible = false;
            Application.Exit();
        }

        private void OnRestart(object sender, EventArgs e)
        {
            _backgroundWorkerStack.TryPeek(out var workersToRemove);
            workersToRemove.CancelAsync();
            workersToRemove.Dispose();
            RemovebackgroundWorkers();

            AddbackgroundWorker();
            _backgroundWorkerStack.TryPeek(out var worker);
            worker.DoWork += BackgroundWorkerOnDoWork;
            worker.ProgressChanged += BackgroundWorkerOnProgressChanged;
            worker.RunWorkerAsync();
            _t.Start();
        }

        private void ActivateTimed_Tick(object sender, EventArgs e)
        {
            _checkState.TimeAnimationNeeded = true;
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