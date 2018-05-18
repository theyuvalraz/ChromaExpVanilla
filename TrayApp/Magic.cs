using System;
using System.Drawing;
using System.Windows.Forms;
using Interfacer.Interfaces;
using TrayApp.Properties;
using CheckState = ChromaExpVanilla.CheckState;

namespace TrayApp
{
    public partial class Magic
    {
        private readonly int _checkInterval = 30;
        private readonly TimeControl _timeControl = new TimeControl();

        private IStateChecker _checkState;

        private NotifyIcon _sysTrayIcon;

        private string _tooltip = string.Empty;

        public Magic()
        {
            InitializeComponent();
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

            _checkState = new CheckState
            {
                FirstAnimationNeeded = true,
                SecondAnimationNeeded = true,
                ClearNeeded = true,
                BaseNeeded = true,
                CurrentStateNeeded = true
            };

            ActivateTimed.Interval = _timeControl.CalculateTimerInterval(_checkInterval);
            ActivateTimed.Start();
            CheckChanges.Start();

            base.OnLoad(e);
        }


        private void OnExit(object sender, EventArgs e)
        {
            _sysTrayIcon.Visible = false;
            Application.Exit();
        }

        private void OnRestart(object sender, EventArgs e)
        {
            _checkState = new CheckState
            {
                FirstAnimationNeeded = true,
                ClearNeeded = true,
                BaseNeeded = true,
                CurrentStateNeeded = true
            };
            ActivateTimed.Start();
        }

        private void ActivateTimed_Tick(object sender, EventArgs e)
        {
            _checkState.TimeAnimationNeeded = true;
            ActivateTimed.Interval = _timeControl.CalculateTimerInterval(_checkInterval);
        }

        private void CheckChanges_Tick(object sender, EventArgs e)
        {
            var state = _checkState.States();
            state?.Invoke();
        }
    }
}