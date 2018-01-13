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
        int PlayerLives = 3;
        bool StartofGame = true;

        //ball variables
        float Speed; //speed of ball
        Vector2 Position, Velocity; //position and velocity of the ball


        public GameClient()
        {
            InitializeComponent();
            lblGamePaused.Text = String.Empty;
            lblPressEnter.Text = String.Empty;
        }

        private void tmrGame_Tick(object sender, EventArgs e)
        {
            //this event will run when enabled and for each time intveral set in properties

            //clearing lables
            lblGamePaused.Text = string.Empty;
            lblPressEnter.Text = string.Empty;
            lblWelcome.Text = string.Empty;
            lblBegin.Text = string.Empty;
            lblForHelp.Text = string.Empty;

            //game has now started
            StartofGame = false;

            //Move player
            if (Player == PlayerState.Left)
            {
                picPlayer.Left -= 10;
            }

            else if (Player == PlayerState.Right)
            {
                picPlayer.Left += 10;
            }  

            //draw ball
            Position += Velocity;
            picBall.Left = (int)Position.X;
            picBall.Top = (int)Position.Y;


            //detect collision between ball and paddle
            if (picPlayer.Bounds.IntersectsWith(picBall.Bounds))
            {
                Collision();
            }

            //detect collision between ball and brick


            //Change direction of the ball

            //ball hits the top of the client
            if (picBall.Top <= 0)
            {
                Velocity.Y *= -1;
            }

            //ball hits the left or right side of the client
            if (picBall.Left <= 0 || picBall.Right >= ClientSize.Width)
            {
                Velocity.X *= -1;
            }

            //losing a life
            if(picBall.Top >= ClientSize.Height)
            {
                //deductingn a life and displaying it
                PlayerLives -= 1;
                lblLives.Text = "Lives left: " + PlayerLives;
                
                //resetting the ball's location
                Reset();
                Velocity.X = 0;
                Velocity.Y = 0;
            }

            //check if out of lives
            if(PlayerLives <= 0)
            {
                //resetting the ball's location
                Reset();
                Velocity.X = 0;
                Velocity.Y = 0;

                //reset player
                PlayerLives = 3;
                Player = PlayerState.None;
                MessageBox.Show("GAME OVER.");
                lblLives.Text = "Lives left: " + PlayerLives;
            }
        }

        private void GameClient_KeyDown(object sender, KeyEventArgs e)
        {
            //this event will run when a key is pressed.

            //if return is pressed, enable the timer, unpausing the game
            if (e.KeyCode == Keys.Return)
            {
                if (tmrGame.Enabled == false)
                {
                    tmrGame.Enabled = true;
                }
            }

            //if space key is pressed, start the game.
            if (e.KeyCode == Keys.Space)
            {
                if (StartofGame == true)
                {
                    //Start the game;
                    Reset();
                    tmrGame.Enabled = true;
                }
            }

            //if escape key is pressed, disable the timer, pausing the game.
            if (e.KeyCode == Keys.Escape)
            {
                tmrGame.Enabled = false;
                lblGamePaused.Text = "Game Paused";
                lblPressEnter.Text = "Press ENTER to continue.";
            }

            //check if left is pressed
            if (e.KeyCode == Keys.Left)
            {
                if (picPlayer.Left - 10 <= 0)
                {
                    //at edge of screen
                    picPlayer.Left = 1;
                    Player = PlayerState.None;
                }
                else
                {
                    Player = PlayerState.Left;
                }
            }

            //check if right is pressed
            if (e.KeyCode == Keys.Right)
            {
                if (picPlayer.Left + 110 >= ClientSize.Width)
                {
                    //at edge of screen
                    picPlayer.Left = ClientSize.Width - 100;
                    Player = PlayerState.None;
                }
                else
                {
                    Player = PlayerState.Right;
                }
            }

            //check if equals button is pressed
            if(e.KeyCode == Keys.Oemplus)
            {
                tmrGame.Enabled = false;
                MessageBox.Show("Welcome to Breakout!\nThe rules of the game are simple:\n\nYou are the paddle on the bottom of the screen." +
               " With the ball as your only weapon, you are to destroy all bricks within the level.");

                MessageBox.Show("These bricks come in different types.\n\nGreen bricks take one (1) hit to destroy." +
                    "\n\nOrange bricks take two (2) hits to destroy.\n\nRed bricks take three (3) hits to destroy." +
                    "\n\nYou must destoy all of the bricks to advance to the next level.");

                MessageBox.Show("The ball bounces off of everything - you, the bricks, and the edges of the level." +
                    "\nAnd whenever it does so, it picks up speed.\n\nHowever, if the ball hits the bottom of the level, you lose a life." +
                    "\nWatch out, you only have 3 lives!\nRemaining lives are labeled at the top right of the screen at all times.");

                MessageBox.Show("Press left or right arrow to move the paddle.\n\nPress Escape to pause the game." +
                    "\nPress Enter/Return to resume the game.");

                lblPressEnter.Text = "Press ENTER to continue.";
            }
        }

        private void GameClient_KeyUp(object sender, KeyEventArgs e)
        {
            //This event will run when a key is let go

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                Player = PlayerState.None;
            }
        }

        private void mnuRestart_Click(object sender, EventArgs e)
        {
            //Restart the game and all values

            //reset the ball
            Reset();
            Velocity.X = 0;
            Velocity.Y = 0;

            //draw ball
            Position += Velocity;
            picBall.Left = (int)Position.X;
            picBall.Top = (int)Position.Y;

            //reset the player
            PlayerLives = 3;
            Player = PlayerState.None;
            picPlayer.Left = 368;
            tmrGame.Enabled = false;

            //reset the labels
            lblLives.Text = "Lives Left: " + PlayerLives;
            lblWelcome.Text = "Welcome!";
            lblBegin.Text = "Please press the SPACEBAR to play.";
            lblForHelp.Text = "For controls and rules of the game,\n              press ''='' at any time.";
            lblGamePaused.Text = String.Empty;
            lblPressEnter.Text = String.Empty;

            //game has not begun
            StartofGame = false;
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuLevels_Click(object sender, EventArgs e)
        {

        }

        private void mnuTutorial_Click(object sender, EventArgs e)
        {
           
        }

        private void controlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //game controls
            MessageBox.Show("Press left or right arrow to move the paddle.\n\nPress Escape to pause the game." +
                "\nPress Enter/Return to resume the game.");
        }

        private void rulesOfTheGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //game rules
            MessageBox.Show("You are the paddle on the bottom of the screen. Use the ball to destroy all of the bricks.");

            MessageBox.Show("Green bricks take one (1) hit to destroy.\n\nOrange bricks take two (2) hits to destroy." +
                "\n\nRed bricks take three (3) hits to destroy.\n\nYou must destoy all of the bricks to advance to the next level.");

            MessageBox.Show("The ball bounces off of everything except the bottom of the level, and picks up speed as it does so." +
                "\nIf the ball reaches the bottom of the level, you lose a life.\nWatch out, you only have 3 lives!" +
                "\nRemaining lives are labeled at the top right of the screen at all times.");
        }

        private void GameClient_Load(object sender, EventArgs e)
        {

        }

        //Methods for the ball

        //Method for finding a random angle.
        float FindRandomAngle()
        {
            Random RandomAngle = new Random();

            int r = 0;
            while (r % 2 == 0)
            {
                r = RandomAngle.Next(1, 8);
            }
            float Angle = MathHelper.ToRadians(r * 45);

            return Angle;
        }

        //Method for resetting the ball
        void Reset()
        {
            Speed = 6;
            Position = new Vector2((ClientSize.Width - picBall.Width) / 2, (ClientSize.Height - (picBall.Height * 4)));
            float Angle = FindRandomAngle();
            Velocity = new Vector2((float)(Speed * Math.Cos(Angle)), (float)(Speed * Math.Sin(Angle)));
        }

        //Method for collisions        
        public void Collision()
        {
            //max speed is 11
            if (Speed < 15)
            {
                Velocity.X *= 1.1f;
                Velocity.Y *= -1.1f;

                Speed = (float)Velocity.Length();
            }
            else
            {
                Velocity.X *= 1;
                Velocity.Y *= -1;
            }
        }

    }//end of form
}