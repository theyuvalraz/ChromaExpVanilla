using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChromaExpVanila;
using ChromaExpVanila.config;
using CheckState = ChromaExpVanila.CheckState;

namespace TrayApp
{
    public partial class Magic : Form
    {
        private NotifyIcon sysTrayIcon;
        private readonly KeyControl _control = new KeyControl();
        private readonly KeyBlocks _blocks = new KeyBlocks();
        private Executor _executor = new Executor();
        private string tooltip = String.Empty;

        public Magic()
        {
            InitializeComponent();




        }




        protected override async void OnLoad( EventArgs e )
        {
            Visible = false;
            ShowInTaskbar = false;
            var sysTrayMenu = new ContextMenu();
            sysTrayMenu.MenuItems.Add( "Exit", OnExit );
            sysTrayIcon = new NotifyIcon();
            tooltip = "Chroma Indicator";
            sysTrayIcon.Text = tooltip;
            sysTrayIcon.Icon = new Icon( SystemIcons.Shield, 40, 40 );
            sysTrayIcon.ContextMenu = sysTrayMenu;
            sysTrayIcon.Visible = true;

            await _control.SetColorBase();
            await _control.Animation( _blocks.AnimationConcept );
            _control.InitiateCustom();

            BackgroundWorker backgroundWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            backgroundWorker.DoWork += BackgroundWorkerOnDoWork;
            backgroundWorker.ProgressChanged += BackgroundWorkerOnProgressChanged;
            backgroundWorker.RunWorkerAsync();
            base.OnLoad( e );
        }

        private void BackgroundWorkerOnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            List<EventTypes> eventsType = new List<EventTypes>();
            eventsType.Add((EventTypes) Enum.ToObject(typeof(EventTypes), e.ProgressPercentage));
            try
            {
                _executor.StateHandler(eventsType, _control).Invoke();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void BackgroundWorkerOnDoWork( object sender, DoWorkEventArgs e )
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            CheckState checkState = new CheckState();

            while (!worker.CancellationPending)
            {
                foreach (var state in checkState.States)
                {
                    worker.ReportProgress( state.GetHashCode() );
                }
            }
        }
        



        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OnEnabled(object sender, EventArgs e)
        {
        }


        private void OnDisabled(object sender, EventArgs e)
        {
        }


        private void OnShowed(object sender, EventArgs e)
        {
        }
    }
}