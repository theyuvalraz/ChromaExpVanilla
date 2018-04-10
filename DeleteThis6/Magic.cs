using System;
using System.Drawing;
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
            var sysTrayMenu = new ContextMenu();
            sysTrayMenu.MenuItems.Add("Exit", OnExit);
            sysTrayIcon = new NotifyIcon();
            tooltip = "Chroma Indicator";
            sysTrayIcon.Text = tooltip;
            sysTrayIcon.Icon = new Icon(SystemIcons.Shield, 40, 40);
            sysTrayIcon.ContextMenu = sysTrayMenu;
            sysTrayIcon.Visible = true;
        }

        protected override async void OnLoad(EventArgs e)

        {
            CheckState checkState = new CheckState();

            Visible = false;
            ShowInTaskbar = false;
            base.OnLoad(e);

            await _control.SetColorBase();
            _control.Animation(_blocks.AnimationConcept);
            _control.InitiateCustom();
            _executor.StateHandler(checkState.States, _control).Invoke();
            _executor.GetEventsLoop(checkState);

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