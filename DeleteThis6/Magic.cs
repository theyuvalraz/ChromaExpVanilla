using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChromaExpVanilla;
using ChromaExpVanilla.config;
using CheckState = ChromaExpVanilla.CheckState;

namespace DeleteThis6
{
    public partial class Magic : Form
    {
        private NotifyIcon sysTrayIcon;
        private readonly KeyControl _control = new KeyControl();
        private readonly KeyBlocks _blocks = new KeyBlocks();
        private CheckState _checkState = new CheckState();
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

            Visible = false;
            ShowInTaskbar = false;
            base.OnLoad(e);

            await _control.SetColorBase();
            _control.Animation(_blocks.AnimationConcept);
            _control.InitiateCustom();
            _executor.StateHandler(_checkState.States).Invoke();
            _executor.GetEventsLoop(_checkState);

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