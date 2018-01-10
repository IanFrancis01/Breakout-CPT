using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using System.Threading;


namespace Breakout_Game
{
    public partial class GameClient : Form
    {
        public GameClient()
        {
            InitializeComponent();
        }

        private void tmrGame_Tick(object sender, EventArgs e)
        {
            //this event will run when enabled and for each time intveral set in properties
            
        }

        private void GameClient_KeyDown(object sender, KeyEventArgs e)
        {
            //this event will run when a key is pressed.
           // MessageBox.Show("Key pressed " + e.KeyCode);
            picBall.Top -= 1;

            //if return is pressed, enable the timer
            if (e.KeyCode == Keys.Return)
            {
                tmrGame.Enabled = true;
            }

            //if escape key is pressed, disable the timer
            else if (e.KeyCode == Keys.Escape) tmrGame.Enabled = false;

            //check if left is pressed
            else if (e.KeyCode == Keys.Left)
            {
                picBallPaddle.Left -= 10;
            }

            //check if right is pressed
            else if (e.KeyCode == Keys.Right)
            {
                picBallPaddle.Left += 10;
            }

        }

        private void mnuClose_Click(object sender, EventArgs e)
        {

        }
    }
}
