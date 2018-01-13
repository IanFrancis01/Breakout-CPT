namespace Breakout_Game
{
    partial class GameClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameClient));
            this.picPlayer = new System.Windows.Forms.PictureBox();
            this.picBall = new System.Windows.Forms.PictureBox();
            this.tmrGame = new System.Windows.Forms.Timer(this.components);
            this.mnuMenu = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPause = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLevels = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTutorial = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblLives = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBall)).BeginInit();
            this.mnuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // picPlayer
            // 
            this.picPlayer.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.picPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPlayer.Location = new System.Drawing.Point(368, 522);
            this.picPlayer.Name = "picPlayer";
            this.picPlayer.Size = new System.Drawing.Size(100, 20);
            this.picPlayer.TabIndex = 0;
            this.picPlayer.TabStop = false;
            // 
            // picBall
            // 
            this.picBall.BackColor = System.Drawing.SystemColors.Window;
            this.picBall.Location = new System.Drawing.Point(405, 480);
            this.picBall.Name = "picBall";
            this.picBall.Size = new System.Drawing.Size(25, 25);
            this.picBall.TabIndex = 1;
            this.picBall.TabStop = false;
            // 
            // tmrGame
            // 
            this.tmrGame.Interval = 10;
            this.tmrGame.Tick += new System.EventHandler(this.tmrGame_Tick);
            // 
            // mnuMenu
            // 
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuHelp});
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.Size = new System.Drawing.Size(836, 24);
            this.mnuMenu.TabIndex = 2;
            this.mnuMenu.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPause,
            this.mnuRestart,
            this.mnuLevels,
            this.mnuClose});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuPause
            // 
            this.mnuPause.Name = "mnuPause";
            this.mnuPause.Size = new System.Drawing.Size(112, 22);
            this.mnuPause.Text = "Pause";
            // 
            // mnuRestart
            // 
            this.mnuRestart.Name = "mnuRestart";
            this.mnuRestart.Size = new System.Drawing.Size(112, 22);
            this.mnuRestart.Text = "Restart";
            // 
            // mnuLevels
            // 
            this.mnuLevels.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.mnuLevels.Name = "mnuLevels";
            this.mnuLevels.Size = new System.Drawing.Size(112, 22);
            this.mnuLevels.Text = "Levels";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem2.Text = "1";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem3.Text = "2";
            // 
            // mnuClose
            // 
            this.mnuClose.Name = "mnuClose";
            this.mnuClose.Size = new System.Drawing.Size(112, 22);
            this.mnuClose.Text = "Close...";
            this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTutorial});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "Help";
            // 
            // mnuTutorial
            // 
            this.mnuTutorial.Name = "mnuTutorial";
            this.mnuTutorial.Size = new System.Drawing.Size(115, 22);
            this.mnuTutorial.Text = "Tutorial";
            this.mnuTutorial.Click += new System.EventHandler(this.mnuTutorial_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::Breakout_Game.Properties.Resources.bricktexture11;
            this.pictureBox1.Location = new System.Drawing.Point(12, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(91, 25);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblLives
            // 
            this.lblLives.AutoSize = true;
            this.lblLives.BackColor = System.Drawing.Color.Transparent;
            this.lblLives.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLives.ForeColor = System.Drawing.Color.White;
            this.lblLives.Location = new System.Drawing.Point(713, 37);
            this.lblLives.Name = "lblLives";
            this.lblLives.Size = new System.Drawing.Size(111, 21);
            this.lblLives.TabIndex = 4;
            this.lblLives.Text = "Lives left: 3";
            // 
            // GameClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(836, 580);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.picBall);
            this.Controls.Add(this.picPlayer);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.lblLives);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.mnuMenu;
            this.Name = "GameClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Breakout";
            this.Load += new System.EventHandler(this.GameClient_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameClient_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameClient_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBall)).EndInit();
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPlayer;
        private System.Windows.Forms.PictureBox picBall;
        private System.Windows.Forms.Timer tmrGame;
        private System.Windows.Forms.MenuStrip mnuMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuPause;
        private System.Windows.Forms.ToolStripMenuItem mnuRestart;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.ToolStripMenuItem mnuLevels;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuTutorial;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblLives;
    }
}

