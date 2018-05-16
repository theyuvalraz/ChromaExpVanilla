using System.ComponentModel;
using System.Windows.Forms;

namespace TrayApp
{
    partial class Magic : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ActivateTimed = new System.Windows.Forms.Timer(this.components);
            this.CheckChanges = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ActivateTimed
            // 
            this.ActivateTimed.Tick += new System.EventHandler(this.ActivateTimed_Tick);
            // 
            // CheckChanges
            // 
            this.CheckChanges.Interval = 250;
            this.CheckChanges.Tick += new System.EventHandler(this.CheckChanges_Tick);
            // 
            // Magic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 64);
            this.Name = "Magic";
            this.Text = "Magic";
            this.ResumeLayout(false);

        }

        #endregion

        private Timer ActivateTimed;
        private Timer CheckChanges;
    }
}

