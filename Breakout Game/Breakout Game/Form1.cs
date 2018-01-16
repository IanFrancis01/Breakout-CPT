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

    // paddle default position picPlayer.Left = 368;

    public partial class GameClient : Form
    {
        
        
        
        ///////////////////////////////////////////////////
        ////////////////GLOBAL VARIABLES//////////////////
        /////////////////////////////////////////////////




        PlayerState Player = PlayerState.None;
        int PlayerLives = 3;
        //prevents user from being able to hit space during game
        bool CanSpace = true;

        //prevents user from being able hit enter during game
        bool startofgame = true;

        //Ball variables
        //Ball GameBall = new Ball(picBall);
        float Speed; //speed of ball
        Vector2 Position, Velocity; //position and velocity of the ball


        public GameClient()
        {
            InitializeComponent();
            lblGamePaused.Text = String.Empty;
            lblPressEnter.Text = String.Empty;
        }




        ///////////////////////////////////////////////////
        //////////////////UNPAUSED GAME///////////////////
        /////////////////////////////////////////////////




        private void tmrGame_Tick(object sender, EventArgs e)
        {
            if(startofgame == true)
            {
                picPlayer.Left = 368;
                startofgame = false;
            }
            else
            {
                startofgame = false;
            }
            //This event will run when enabled and for each time intveral set in properties

            //Clearing lables
            lblGamePaused.Text = String.Empty;
            lblPressEnter.Text = String.Empty;
            lblWelcome.Text = String.Empty;
            lblBegin.Text = String.Empty;
            lblForHelp.Text = String.Empty;

            //Move player
            if (Player == PlayerState.Left)
            {
                if (picPlayer.Left - 10 <= 0)
                {
                    //at edge of screen
                    Player = PlayerState.None;
                }
                else
                {
                    picPlayer.Left -= 10;
                }
            }

            else if (Player == PlayerState.Right)
            {
                if (picPlayer.Right + 10 >= ClientSize.Width)
                {
                    //at edge of screen
                    Player = PlayerState.None;
                }
                else
                {
                    picPlayer.Left += 10;
                }
            }

            //Draw ball
            Position += Velocity;
            picBall.Left = (int)Position.X;
            picBall.Top = (int)Position.Y;


            //Detect collision between ball and paddle
            if (picPlayer.Bounds.IntersectsWith(picBall.Bounds))
            {
                    Collision();
            }

            //Detect collision between ball and brick

            //Ball hits the top of the client
            if (picBall.Top <= 0)
            {
                Velocity.Y *= -1;
            }

            //Ball hits the left or right side of the client
            if (picBall.Left <= 0 || picBall.Right >= ClientSize.Width)
            {
                Velocity.X *= -1;
            }

            //Losing a life
            if(picBall.Top >= ClientSize.Height)
            {
                //resetting the ball's location
                Reset();
                Velocity.X = 0;
                Velocity.Y = 0;

                //deducting a life and displaying it
                PlayerLives -= 1;
                lblLives.Text = "Lives left: " + PlayerLives;
                CanSpace = true;
            }

            //Check if out of lives
            if(PlayerLives <= 0)
            {
                //reset the game and all values

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

                //reset labels and other
                lblGamePaused.Text = "GAME OVER.";
                lblPressEnter.Text = "Press SPACEBAR to start over.";
                lblLives.Text = "Lives left: " + PlayerLives;
                tmrGame.Enabled = false;
                startofgame = true;
                CanSpace = true;
            }
        }



        ///////////////////////////////////////////////////
        ///////////////////KEY DOWN/UP////////////////////
        /////////////////////////////////////////////////




        private void GameClient_KeyDown(object sender, KeyEventArgs e)
        {
            //This event will run when a key is pressed.

            //If return is pressed, enable the timer, unpausing the game
            if (e.KeyCode == Keys.Return)
            {
                if (tmrGame.Enabled == false && startofgame == false)
                {
                    tmrGame.Enabled = true;
                }
            }

            //If space key is pressed, start the game.
            if (e.KeyCode == Keys.Space)
            {
                if (CanSpace == true)
                {
                    Reset();
                    tmrGame.Enabled = true;
                    CanSpace = false;
                }
            }

            //If escape key is pressed, disable the timer, pausing the game.
            if (e.KeyCode == Keys.Escape)
            {
                tmrGame.Enabled = false;
                lblGamePaused.Text = "Game Paused";

                if (startofgame == true)
                {
                    lblPressEnter.Text = "Press SPACEBAR to begin.";
                }
                else
                {
                    lblPressEnter.Text = "Press ENTER to continue.";
                }
            }

            //Check if left is pressed
            if (e.KeyCode == Keys.Left)
            {
                {
                    Player = PlayerState.Left;
                }
            }

            //Check if right is pressed
            if (e.KeyCode == Keys.Right)
            {
                    Player = PlayerState.Right;
            }

            //Check if F1 key is pressed
            if(e.KeyCode == Keys.F1)
            {
                ResetGame();
            }

            //Check if equals button is pressed
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

                MessageBox.Show("Press the left or right arrow to move the paddle.\n\nPress Escape to pause the game." +
                "\nPress Enter to resume the game.\n\nYou can also press Equals (=) to bring up the rules and controls.");

                if (startofgame == true)
                {
                    lblPressEnter.Text = "Press SPACEBAR to begin.";
                }
                else
                {
                    lblPressEnter.Text = "Press ENTER to continue.";
                }
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




        ///////////////////////////////////////////////////
        ///////////////////MENU BUTONS////////////////////
        /////////////////////////////////////////////////




        private void mnuRestart_Click(object sender, EventArgs e)
        {
            //Restart the game and all values
            ResetGame();
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            //Exit the game
            Application.Exit();
        }

        private void controlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Game controls
            tmrGame.Enabled = false;
            MessageBox.Show("Press the left or right arrow to move the paddle.\n\nPress Escape to pause the game." +
                "\nPress Enter to resume the game.\n\nYou can also press Equals (=) to bring up the rules and controls.");

            if (startofgame == true)
            {
                lblPressEnter.Text = "Press SPACEBAR to begin.";
            }
            else
            {
                lblPressEnter.Text = "Press ENTER to continue.";
            }
        }

        private void rulesOfTheGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Game rules
            tmrGame.Enabled = false;
            MessageBox.Show("You are the paddle on the bottom of the screen. Use the ball to destroy all of the bricks.");

            MessageBox.Show("Green bricks take one (1) hit to destroy.\n\nOrange bricks take two (2) hits to destroy." +
                "\n\nRed bricks take three (3) hits to destroy.\n\nYou must destoy all of the bricks to advance to the next level.");

            MessageBox.Show("The ball bounces off of everything except the bottom of the level, and picks up speed as it does so." +
                "\nIf the ball reaches the bottom of the level, you lose a life.\nWatch out, you only have 3 lives!" +
                "\nRemaining lives are labeled at the top right of the screen at all times.");

            if (startofgame == true)
            {
                lblPressEnter.Text = "Press SPACEBAR to begin.";
            }
            else
            {
                lblPressEnter.Text = "Press ENTER to continue.";
            }
        }

        private void mnuLevels_Click(object sender, EventArgs e)
        {

        }

        private void mnuTutorial_Click(object sender, EventArgs e)
        {

        }

        private void GameClient_Load(object sender, EventArgs e)
        {

        }

        
        
        
        ///////////////////////////////////////////////////
        /////////////////////METHODS//////////////////////
        /////////////////////////////////////////////////




        //methods for form
        void ResetGame()
        {
            //Reset the ball
            Reset();
            Velocity.X = 0;
            Velocity.Y = 0;

            //Draw ball
            Position += Velocity;
            picBall.Left = (int)Position.X;
            picBall.Top = (int)Position.Y;

            //Reset the player
            PlayerLives = 3;
            Player = PlayerState.None;
            picPlayer.Left = 368;

            //Reset the labels
            lblLives.Text = "Lives Left: " + PlayerLives;
            lblWelcome.Text = "Welcome!";
            lblBegin.Text = "Please press the SPACEBAR to play.";
            lblForHelp.Text = "For controls and rules of the game,\n              press ''='' at any time.";
            lblGamePaused.Text = String.Empty;
            lblPressEnter.Text = String.Empty;

            //reset all booleans
            tmrGame.Enabled = false;
            CanSpace = true;
            startofgame = true;
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
                Velocity.Y *= -1;
            }
        }

    }//End of form
}