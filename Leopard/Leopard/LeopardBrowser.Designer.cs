namespace Leopard
{
    partial class LeopardBrowser
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
            this.content = new System.Windows.Forms.SplitContainer();
            this.url = new System.Windows.Forms.TextBox();
            this.back = new System.Windows.Forms.PictureBox();
            this.forward = new System.Windows.Forms.PictureBox();
            this.refresh = new System.Windows.Forms.PictureBox();
            this.home = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.content)).BeginInit();
            this.content.Panel1.SuspendLayout();
            this.content.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.back)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.home)).BeginInit();
            this.SuspendLayout();
            // 
            // content
            // 
            this.content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.content.Location = new System.Drawing.Point(0, 0);
            this.content.Name = "content";
            this.content.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // content.Panel1
            // 
            this.content.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.content.Panel1.Controls.Add(this.home);
            this.content.Panel1.Controls.Add(this.refresh);
            this.content.Panel1.Controls.Add(this.forward);
            this.content.Panel1.Controls.Add(this.back);
            this.content.Panel1.Controls.Add(this.url);
            this.content.Panel1MinSize = 0;
            // 
            // content.Panel2
            // 
            this.content.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.content.Panel2MinSize = 0;
            this.content.Size = new System.Drawing.Size(839, 456);
            this.content.SplitterDistance = 37;
            this.content.TabIndex = 0;
            // 
            // url
            // 
            this.url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.url.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.url.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.url.Location = new System.Drawing.Point(114, 3);
            this.url.MaxLength = 2147483647;
            this.url.MinimumSize = new System.Drawing.Size(0, 32);
            this.url.Name = "url";
            this.url.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.url.Size = new System.Drawing.Size(684, 32);
            this.url.TabIndex = 0;
            this.url.Text = "http://www.google.com";
            this.toolTip1.SetToolTip(this.url, "The URL to view");
            this.url.KeyUp += new System.Windows.Forms.KeyEventHandler(this.url_KeyUp);
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(3, 3);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(32, 32);
            this.back.TabIndex = 1;
            this.back.TabStop = false;
            this.toolTip1.SetToolTip(this.back, "Go to the previous webpage");
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // forward
            // 
            this.forward.Location = new System.Drawing.Point(41, 3);
            this.forward.Name = "forward";
            this.forward.Size = new System.Drawing.Size(32, 32);
            this.forward.TabIndex = 2;
            this.forward.TabStop = false;
            this.toolTip1.SetToolTip(this.forward, "Go to the next webpage");
            this.forward.Click += new System.EventHandler(this.forward_Click);
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(79, 3);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(32, 32);
            this.refresh.TabIndex = 3;
            this.refresh.TabStop = false;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // home
            // 
            this.home.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.home.Location = new System.Drawing.Point(804, 3);
            this.home.Name = "home";
            this.home.Size = new System.Drawing.Size(32, 32);
            this.home.TabIndex = 4;
            this.home.TabStop = false;
            this.toolTip1.SetToolTip(this.home, "Go to Google");
            this.home.Click += new System.EventHandler(this.home_Click);
            // 
            // LeopardBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(839, 456);
            this.Controls.Add(this.content);
            this.Name = "LeopardBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading Leopard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LeopardBrowser_FormClosing);
            this.Load += new System.EventHandler(this.LeopardBrowser_Load);
            this.content.Panel1.ResumeLayout(false);
            this.content.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.content)).EndInit();
            this.content.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.back)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.home)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer content;
        private System.Windows.Forms.PictureBox refresh;
        private System.Windows.Forms.PictureBox forward;
        private System.Windows.Forms.PictureBox back;
        private System.Windows.Forms.TextBox url;
        private System.Windows.Forms.PictureBox home;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}