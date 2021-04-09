namespace CustomClock
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hourClockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hourClockToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.stopWatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.txtCountDownTime = new System.Windows.Forms.TextBox();
            this.cmdStartCountDown = new System.Windows.Forms.Button();
            this.cmdToggleTimer = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(500, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hourClockToolStripMenuItem,
            this.hourClockToolStripMenuItem1,
            this.toolStripSeparator1,
            this.stopWatchToolStripMenuItem,
            this.countdownToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // hourClockToolStripMenuItem
            // 
            this.hourClockToolStripMenuItem.Name = "hourClockToolStripMenuItem";
            this.hourClockToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.hourClockToolStripMenuItem.Text = "12 Hour Clock";
            this.hourClockToolStripMenuItem.Click += new System.EventHandler(this.clockToolStripMenuItem_Click);
            // 
            // hourClockToolStripMenuItem1
            // 
            this.hourClockToolStripMenuItem1.Name = "hourClockToolStripMenuItem1";
            this.hourClockToolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
            this.hourClockToolStripMenuItem1.Text = "Digital Clock";
            this.hourClockToolStripMenuItem1.Click += new System.EventHandler(this.digitalClockToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(146, 6);
            // 
            // stopWatchToolStripMenuItem
            // 
            this.stopWatchToolStripMenuItem.Name = "stopWatchToolStripMenuItem";
            this.stopWatchToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.stopWatchToolStripMenuItem.Text = "Stop Watch";
            this.stopWatchToolStripMenuItem.Click += new System.EventHandler(this.stopwatchToolStripMenuItem_Click);
            // 
            // countdownToolStripMenuItem
            // 
            this.countdownToolStripMenuItem.Name = "countdownToolStripMenuItem";
            this.countdownToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.countdownToolStripMenuItem.Text = "Countdown";
            this.countdownToolStripMenuItem.Click += new System.EventHandler(this.countdownToolStripMenuItem_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // txtCountDownTime
            // 
            this.txtCountDownTime.Location = new System.Drawing.Point(13, 28);
            this.txtCountDownTime.Name = "txtCountDownTime";
            this.txtCountDownTime.Size = new System.Drawing.Size(140, 20);
            this.txtCountDownTime.TabIndex = 1;
            this.txtCountDownTime.Text = "00:00:00:0";
            // 
            // cmdStartCountDown
            // 
            this.cmdStartCountDown.Location = new System.Drawing.Point(159, 28);
            this.cmdStartCountDown.Name = "cmdStartCountDown";
            this.cmdStartCountDown.Size = new System.Drawing.Size(329, 20);
            this.cmdStartCountDown.TabIndex = 2;
            this.cmdStartCountDown.Text = "Start Countdown";
            this.cmdStartCountDown.UseVisualStyleBackColor = true;
            this.cmdStartCountDown.Click += new System.EventHandler(this.cmdStartCountDown_Click);
            // 
            // cmdToggleTimer
            // 
            this.cmdToggleTimer.Location = new System.Drawing.Point(12, 27);
            this.cmdToggleTimer.Name = "cmdToggleTimer";
            this.cmdToggleTimer.Size = new System.Drawing.Size(324, 20);
            this.cmdToggleTimer.TabIndex = 3;
            this.cmdToggleTimer.Text = "Start";
            this.cmdToggleTimer.UseVisualStyleBackColor = true;
            this.cmdToggleTimer.Click += new System.EventHandler(this.cmdToggleTimer_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.Location = new System.Drawing.Point(343, 27);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(145, 20);
            this.cmdReset.TabIndex = 4;
            this.cmdReset.Text = "Reset";
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.cmdReset);
            this.Controls.Add(this.cmdToggleTimer);
            this.Controls.Add(this.cmdStartCountDown);
            this.Controls.Add(this.txtCountDownTime);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clock+ - 12 Hour Clock";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem hourClockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hourClockToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem stopWatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem countdownToolStripMenuItem;
        private System.Windows.Forms.TextBox txtCountDownTime;
        private System.Windows.Forms.Button cmdStartCountDown;
        private System.Windows.Forms.Button cmdToggleTimer;
        private System.Windows.Forms.Button cmdReset;
    }
}

