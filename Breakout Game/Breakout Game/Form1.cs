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
    enum PlayerState
    {
        Left,
        Right,
        None
    }

    public partial class GameClient : Form
    {

        //global variables
        PlayerState Player = PlayerState.None;


        public GameClient()
        {
            InitializeComponent();
            // tmrGame.Enabled = false;
            /*
            MessageBox.Show("Welcome to Breakout!\nBefore we begin, here are the controls:\n\nPress left or right arrow to move the paddle.\n\nPress Escape to pause the game.\n\nPress Enter/Return to resume the game.");
            MessageBox.Show("For a the rules of the game and more, please refer to the ''Help'' tab on the top left.");
            MessageBox.Show("After closing this box, please press Enter/Return to begin.");
             */
        }

        private void tmrGame_Tick(object sender, EventArgs e)
        {
            //this event will run when enabled and for each time intveral set in properties
            picBall.Top -= 1;

        }

        private void GameClient_KeyDown(object sender, KeyEventArgs e)
        {
            //this event will run when a key is pressed.
            // MessageBox.Show("Key pressed " + e.KeyCode);


            //if return is pressed, enable the timer
            if (e.KeyCode == Keys.Return)
            {
                tmrGame.Enabled = true;
            }



            //if the game is unpaused
            if (tmrGame.Enabled == true)
            {

                //if escape key is pressed, disable the timer
                if (e.KeyCode == Keys.Escape) tmrGame.Enabled = false;

                //check if left is pressed
                if (e.KeyCode == Keys.Left)
                {
                    if (picBallPaddle.Left - 10 <= 0)
                    {
                        //at edge of screen
                    }
                    else
                    {
                        Player = PlayerState.Left;
                    }
                }

                //check if right is pressed
                if (e.KeyCode == Keys.Right)
                {
                    if (picBallPaddle.Right + 10 >= ClientSize.Width)
                    {
                        //at edge of screen
                    }
                    else
                    {
                        Player = PlayerState.Right;
                    }
                }
            }
        }//end of unpaused game.

        private void mnuClose_Click(object sender, EventArgs e)
        {

        }

        private void GameClient_Load(object sender, EventArgs e)
        {

        }

        private void mnuTutorial_Click(object sender, EventArgs e)
        {

        }

        private void GameClient_KeyUp(object sender, KeyEventArgs e)
        {
            //This event will run when a key is let go

            if (e.KeyCode == Keys.Left)
                Player = PlayerState.None;

            else if (e.KeyCode == Keys.Right)
                Player = PlayerState.None;
        }

    }//end of form
}
