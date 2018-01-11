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
            

            //if return is pressed, enable the timer
            if (e.KeyCode == Keys.Return)
            {
                
                
            }

            //if escape key is pressed, disable the timer
            else if (e.KeyCode == Keys.Escape) tmrGame.Enabled = false;

            //check if left is pressed
             if (e.KeyCode == Keys.Left)
            {
                if (picBallPaddle.Left  - 10 <= 0)
                {

                }
                else
                {
                    picBallPaddle.Left -= 10;
                }
            }

            //check if right is pressed
             if (e.KeyCode == Keys.Right)
            {
                if (picBallPaddle.Right + 10 >= ClientSize.Width)
                {
                }
                else
                {
                    picBallPaddle.Left += 10;
                }
            }

        }

        private void mnuClose_Click(object sender, EventArgs e)
        {

        }

        private void GameClient_Load(object sender, EventArgs e)
        {

        }
    }
}
