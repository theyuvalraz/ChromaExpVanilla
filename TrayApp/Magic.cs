using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ChromaExpVanilla;
using ChromaExpVanilla.config;
using Corale.Colore.Razer.Keyboard;
using CheckState = ChromaExpVanilla.CheckState;
using Color = Corale.Colore.Core.Color;

namespace TrayApp
{
    public partial class Magic
    {
        private const int CheckInterval = 30;
        static System.Windows.Forms.Timer _t;

        private NotifyIcon _sysTrayIcon;

        private readonly KeyControl _control = new KeyControl();
        private readonly KeyBlocks _blocks = new KeyBlocks();

        private string _tooltip = string.Empty;

        private readonly TimeControl _timeControl = new TimeControl();

        readonly BackgroundWorker _backgroundWorker = new BackgroundWorker
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

            _sysTrayIcon = new NotifyIcon();
            _tooltip = "Chroma Indicator";
            _sysTrayIcon.Text = _tooltip;
            _sysTrayIcon.Icon = new Icon(Properties.Resources.Y, 40, 40);
            _sysTrayIcon.ContextMenu = sysTrayMenu;
            _sysTrayIcon.Visible = true;

            await _control.Animation(_blocks.AnimationConcept);
            await _control.FrameAnimation(_blocks.AnimationConceptStage2);
            _control.CustomLayer.Clear();
            await _control.SetColorBase();

            _control.InitiateCustom();

            _backgroundWorker.DoWork += BackgroundWorkerOnDoWork;
            _backgroundWorker.ProgressChanged += BackgroundWorkerOnProgressChanged;
            _backgroundWorker.RunWorkerAsync();

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

            try
            {
                _control.SetCustomKey(Key.F6, Color.Red);
                eventsType.Invoke();
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
                worker.ReportProgress(checkState.States( _control));
            }
        }


        private void OnExit(object sender, EventArgs e)
        {
            _sysTrayIcon.Visible = false;
            Application.Exit();
        }

        private async void OnRestart(object sender, EventArgs e)
        {
            _backgroundWorker.CancelAsync();
            _backgroundWorker.Dispose();
            await _control.Animation(_blocks.AnimationConcept);

            _control.CustomLayer.Clear();
            await _control.SetColorBase();

            if (!_backgroundWorker.IsBusy)
            {
                _control.InitiateCustom();
                _backgroundWorker.RunWorkerAsync();
            }
            _t.Start();
            this.OnRestart2(this, EventArgs.Empty);
        }
        private void OnRestart2(object sender, EventArgs e)
        {

            if (!_backgroundWorker.IsBusy)
            {
                _control.InitiateCustom();
                _backgroundWorker.RunWorkerAsync();
            }
            _t.Start();
        }

        private bool OnDisabled()
        {
            _backgroundWorker.CancelAsync();
            
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
            _t.Interval = _timeControl.CalculateTimerInterval(CheckInterval);
        }
    }

    public static class BackgroundWorkerExt
    {
        public static void ReportProgress(this BackgroundWorker self, Action state)
        {
            const int dummyProgress = 0;
            self.ReportProgress(dummyProgress, state);
        }
    }
}