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
        private NotifyIcon sysTrayIcon;
        private readonly KeyControl _control = new KeyControl();
        private readonly KeyBlocks _blocks = new KeyBlocks();
        private readonly Executor _executor = new Executor();
        private string tooltip = String.Empty;

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
            base.OnLoad(e);
        }

        private void BackgroundWorkerOnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var eventsType = (List<EventTypes>) e.UserState;

            try
            {
                _executor.StateHandler( eventsType, _control ).Invoke();
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
                worker.ReportProgress( checkState.States );
            }
        }


        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void OnRestart(object sender, EventArgs e)
        {
            OnDisabled();
            await _control.Animation(_blocks.AnimationConcept);
            await _control.FrameAnimation(_blocks.AnimationConceptStage2);
            _control.CustomLayer.Clear();
            await _control.SetColorBase();
            _control.InitiateCustom();
            if (!backgroundWorker.IsBusy)
                backgroundWorker.RunWorkerAsync();
        }

        private bool OnDisabled()
        {
            backgroundWorker.CancelAsync();
            return true;
        }
        private void OnEnabled(object sender, EventArgs e)
        {
        }
        private void OnDisabled(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
        }
        private void OnShowed(object sender, EventArgs e)
        {
        }
    }

    public static class BackgroundWorkerExt
    {
        public static void ReportProgress( this BackgroundWorker self, List<EventTypes> state )
        {
            const int DUMMY_PROGRESS = 0;
            self.ReportProgress( DUMMY_PROGRESS, state );
        }
    }
}