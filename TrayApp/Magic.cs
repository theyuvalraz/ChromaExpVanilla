using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChromaExpVanilla;
using ChromaExpVanilla.config;
using CheckState = ChromaExpVanilla.CheckState;

namespace TrayApp
{
    public partial class Magic
    {
        const int CHECK_INTERVAL = 30;
        static System.Windows.Forms.Timer t;

        private NotifyIcon sysTrayIcon;

        private readonly KeyControl _control = new KeyControl();
        private readonly KeyBlocks _blocks = new KeyBlocks();
        private readonly Executor _executor = new Executor();

        private string tooltip = String.Empty;

        private TimeControl timeControl = new TimeControl();

        BackgroundWorker backgroundWorker = new BackgroundWorker
        {
            WorkerReportsProgress = true,
            WorkerSupportsCancellation = true
        };

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

            sysTrayIcon = new NotifyIcon();
            tooltip = "Chroma Indicator";
            sysTrayIcon.Text = tooltip;
            sysTrayIcon.Icon = new Icon(Properties.Resources.Y, 40, 40);
            sysTrayIcon.ContextMenu = sysTrayMenu;
            sysTrayIcon.Visible = true;

            await _control.Animation(_blocks.AnimationConcept);
            await _control.FrameAnimation(_blocks.AnimationConceptStage2);
            _control.CustomLayer.Clear();
            await _control.SetColorBase();

            _control.InitiateCustom();

            backgroundWorker.DoWork += BackgroundWorkerOnDoWork;
            backgroundWorker.ProgressChanged += BackgroundWorkerOnProgressChanged;
            backgroundWorker.RunWorkerAsync();

            t = new System.Windows.Forms.Timer
            {
                Interval = timeControl.CalculateTimerInterval(CHECK_INTERVAL)
            };
            t.Tick += ActivateTimed_Tick;
            t.Start();

            base.OnLoad(e);
        }

        private void BackgroundWorkerOnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var eventsType = (List<EventTypes>) e.UserState;

            try
            {
                _executor.StateHandler(eventsType, _control).Invoke();
            }
            catch (Exception)
            {
            }
        }

        private void BackgroundWorkerOnDoWork(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker) sender;
            var checkState = new CheckState();

            while (!worker.CancellationPending)
            {
                Thread.Sleep(50);
                worker.ReportProgress(checkState.States);
            }
        }


        private void OnExit(object sender, EventArgs e)
        {
            sysTrayIcon.Visible = false;
            Application.Exit();
        }

        private async void OnRestart(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
            backgroundWorker.Dispose();
            await _control.Animation(_blocks.AnimationConcept);

            _control.CustomLayer.Clear();
            await _control.SetColorBase();

            if (!backgroundWorker.IsBusy)
            {
                _control.InitiateCustom();
                backgroundWorker.RunWorkerAsync();
            }
            t.Start();
            this.OnRestart2(this, EventArgs.Empty);
        }
        private async void OnRestart2(object sender, EventArgs e)
        {

            if (!backgroundWorker.IsBusy)
            {
                _control.InitiateCustom();
                backgroundWorker.RunWorkerAsync();
            }
            t.Start();
        }

        private bool OnDisabled()
        {
            backgroundWorker.CancelAsync();
            
            return true;
        }

        private void OnEnabled(object sender, EventArgs e)
        {
        }

        private void OnShowed(object sender, EventArgs e)
        {
        }

        private void ActivateTimed_Tick(object sender, EventArgs e)
        {
            _control.TimeAnimation();
            t.Interval = timeControl.CalculateTimerInterval(CHECK_INTERVAL);
        }
    }

    public static class BackgroundWorkerExt
    {
        public static void ReportProgress(this BackgroundWorker self, List<EventTypes> state)
        {
            const int DUMMY_PROGRESS = 0;
            self.ReportProgress(DUMMY_PROGRESS, state);
        }
    }
}