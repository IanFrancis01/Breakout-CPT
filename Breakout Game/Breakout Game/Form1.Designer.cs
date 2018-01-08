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
            this.BallPaddle = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BallPaddle)).BeginInit();
            this.SuspendLayout();
            // 
            // BallPaddle
            // 
            this.BallPaddle.BackgroundImage = global::Breakout_Game.Properties.Resources.paddle;
            this.BallPaddle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BallPaddle.Location = new System.Drawing.Point(282, 541);
            this.BallPaddle.Name = "BallPaddle";
            this.BallPaddle.Size = new System.Drawing.Size(249, 27);
            this.BallPaddle.TabIndex = 0;
            this.BallPaddle.TabStop = false;
            // 
            // GameClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 580);
            this.Controls.Add(this.BallPaddle);
            this.Name = "GameClient";
            this.Text = "Breakout";
            ((System.ComponentModel.ISupportInitialize)(this.BallPaddle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox BallPaddle;
    }
}

