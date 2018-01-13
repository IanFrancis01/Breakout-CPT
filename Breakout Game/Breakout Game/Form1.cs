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

        //ball variables
        float Speed; //speed of ball
        Vector2 Position, Velocity; //position and velocity of the ball


        public GameClient()
        {
            InitializeComponent();
            /*
            MessageBox.Show("Welcome to Breakout!\nBefore we begin, here are the controls:\n\nPress left or right arrow to move the paddle.\n\nPress Escape to pause the game.\n\nPress Enter/Return to resume the game.");
            MessageBox.Show("For a the rules of the game and more, please refer to the ''Help'' tab on the top left.");
            MessageBox.Show("After closing this box, please press Enter/Return to begin.");
             */
        }

        private void tmrGame_Tick(object sender, EventArgs e)
        {
            //this event will run when enabled and for each time intveral set in properties

            //Move player
            if (Player == PlayerState.Left)
            {
                picPlayer.Left -= 10;
            }
            else if (Player == PlayerState.Right)
            {
                picPlayer.Left += 10;
            }
            else
            {
            }
                

            //draw ball
            Position = Position + Velocity;
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
                Reset();
                //resetting the ball's location
                Reset();
                Velocity.X = 0;
                Velocity.Y = 0;
                PlayerLives = 3;
                //insert code for score reset
                MessageBox.Show("GAME OVER.");
                lblLives.Text = "Lives left: " + PlayerLives;
            }
        }

        private void GameClient_KeyDown(object sender, KeyEventArgs e)
        {
            //this event will run when a key is pressed.

            //if return is pressed, enable the timer
            if (e.KeyCode == Keys.Return)
            {
                //reset the game
                Reset();
                tmrGame.Enabled = true;
            }

            //if escape key is pressed, disable the timer
            if (e.KeyCode == Keys.Escape) tmrGame.Enabled = false;

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
        }

        private void GameClient_KeyUp(object sender, KeyEventArgs e)
        {
            //This event will run when a key is let go

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                Player = PlayerState.None;
            }
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {

        }

        private void GameClient_Load(object sender, EventArgs e)
        {

        }

        private void mnuTutorial_Click(object sender, EventArgs e)
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
            if (Speed < 11)
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
