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
using CardPickerGame;

namespace Breakout_Game
    /* Project: Breakout CPT
     * 
     * Programmers: Shemmar Higgans and Ian Francis
     * 
     * Date: Tuesday January 23rd 2018
     * 
     * Description: The goal of the game is to destroy all of the bricks by hitting them with the ball.
     * You are a paddle that the ball bounces off of.
     */
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

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////SHEMMAR EXPLAIN/////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////
        ////////////////GLOBAL VARIABLES//////////////////
        /////////////////////////////////////////////////

        Grid myGrid;


        //Player-related variables
        PlayerState Player = PlayerState.None;
        int PlayerLives;
        int score = 0;

        //Bug-fixing-related variables
        bool CanSpace = true; //prevents user from being able to hit space during game
        bool startofgame = true; //prevents user from being able hit enter during game
        int[] Fact = new int[8];

        //Ball variables
        float Speed; //speed of ball
        Vector2 Position, Velocity; //position and velocity of the ball

        //brick variables
        PictureBox[,] bricksp = new PictureBox[7, 4];
        int[,] Bricks = {{3, 3, 3, 3, 3, 3, 3, 3},  //An array for the bricks, with the health coded in
                         {3, 3, 3, 3, 3, 3, 3, 3},
                         {2, 2, 2, 2, 2, 2, 2, 2},
                         {2, 2, 2, 2, 2, 2, 2, 2},
                         {1, 1, 1, 1, 1, 1, 1, 1}};


        public GameClient()
        {
            InitializeComponent();
            //clearing labels
            InvisbleBricks();
            lblGamePaused.Text = String.Empty;
            lblPressEnter.Text = String.Empty;
        }




        ///////////////////////////////////////////////////
        //////////////////UNPAUSED GAME///////////////////
        /////////////////////////////////////////////////




        private void tmrGame_Tick(object sender, EventArgs e)
        {
            //drawing the bricks
            Graphics g = this.CreateGraphics();
            myGrid = new Grid(5, 8, 91);
            myGrid.Draw(g,50,100);

            //adjusting the game depending on whether or not game has started, or resuming from a pause.
            if(startofgame == true)
            {
                picPlayer.Left = 368;
                PlayerLives = 3;
                lblLives.Text = "Lives Left: " + PlayerLives;
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
            lblTitle.Text = String.Empty;

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
                //if ball hits the left or right side of the paddle
                if(picBall.Left >= (picPlayer.Right - 12) || picBall.Right <= (picPlayer.Left + 12))
                {
                    Velocity.X *= -1.1f;
                    Velocity.Y *= -1.1f;

                    Position = new Vector2(picBall.Left, (picPlayer.Top - 25));
                }
                else
                {
                    //if the ball does not hit any of the paddle's sides/edges
                    BallCollision();
                }

                //redraw ball
                Position += Velocity;
                picBall.Left = (int)Position.X;
                picBall.Top = (int)Position.Y;
            }

            //Detect collision between ball and brick
            BrickCollision();
            
            //Ball hits the top of the client
            if (picBall.Top <= 24)
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
                ResetBall();
                Velocity.X = 0;
                Velocity.Y = 0;

                //deducting a life and displaying it
                PlayerLives -= 1;
                lblLives.Text = "Lives left: " + PlayerLives;
                CanSpace = true;
            }

            //Check if out of lives
            if(PlayerLives == 0)
            {
                //reset the game and all values
                
                //reset the ball
                ResetBall();
                Velocity.X = 0;
                Velocity.Y = 0;

                //draw ball
                Position += Velocity;
                picBall.Left = (int)Position.X;
                picBall.Top = (int)Position.Y;

                //reset the player
                //PlayerLives = 3;
                Player = PlayerState.None;

                //reset labels and other
                lblGamePaused.Text = "GAME OVER.";
                lblPressEnter.Text = "Press SPACEBAR to start over.";
                lblLives.Text = "Lives Left: " + PlayerLives;
                lblTitle.Text = "Breakout Game";
                tmrGame.Enabled = false;
                startofgame = true;
                CanSpace = true;
            }
        }//END OF METHOD



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
                    lblTitle.Text = "Breakout Game";
                }
            }

            //If space key is pressed, start the game.
            if (e.KeyCode == Keys.Space)
            {
                if (CanSpace == true)
                {
                    ResetBall();
                    tmrGame.Enabled = true;
                    CanSpace = false;
                }
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////SHEMMAR EXPLAIN/////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (e.KeyCode == Keys.Space && PlayerLives <= 0)
            {
                VisibleBricks();
                BrickDecollision();
            }

            //If escape key is pressed, disable the timer, pausing the game.
            if (e.KeyCode == Keys.Escape)
            {
                tmrGame.Enabled = false;
                lblGamePaused.Text = "Game Paused";
                lblTitle.Text = "Breakout Game";

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

            //Easter Egg key
            if (e.KeyCode == Keys.E)
            {
                RandomFacts();

            }
        }//END OF METHOD


        private void GameClient_KeyUp(object sender, KeyEventArgs e)
        {
            //This event will run when a key is let go

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                Player = PlayerState.None;
            }
        }//END OF METHOD




        ///////////////////////////////////////////////////
        ///////////////////MENU BUTONS////////////////////
        /////////////////////////////////////////////////




        private void mnuRestart_Click(object sender, EventArgs e)
        {
            //Restart the game and all values
            ResetGame();
        }//END OF METHOD


        private void mnuClose_Click(object sender, EventArgs e)
        {
            //Exit the game
            Application.Exit();
        }//END OF METHOD


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
        }//END OF METHOD



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
        }//END OF METHOD  
  
        
        ///////////////////////////////////////////////////
        /////////////////////METHODS//////////////////////
        /////////////////////////////////////////////////


        //METHODS FOR THE BALL

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
        }//END OF METHOD


        //Method for resetting the ball
        void ResetBall()
        {
            Speed = 6;
            Position = new Vector2((ClientSize.Width - picBall.Width) / 2, (ClientSize.Height - (picBall.Height * 4)));
            float Angle = FindRandomAngle();
            Velocity = new Vector2((float)(Speed * Math.Cos(Angle)), (float)(Speed * Math.Sin(Angle)));
        }//END OF METHOD


        //Method for ball collisions not including bricks        
        public void BallCollision()
        {
            //max speed is 10
            if (Speed < 10)
            {
                Velocity.X *= 1.1f;
                Velocity.Y *= -1.1f;

                Speed = (float)Velocity.Length();
            }
            else
            {
                Velocity.Y *= -1;
            }
        }//END OF METHOD

        //METHODS FOR BRICKS

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////SHEMMAR EXPLAIN/////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void BrickCollision()
        {
            foreach (Control brick in this.Controls)
            {
                if (brick is PictureBox & brick.Tag == "block")
                {
                    if (picBall.Bounds.IntersectsWith(brick.Bounds))
                    {
                        Controls.Remove(brick);
                        BallCollision();
                        score++;
                    }

                }
            }
        }//END OF METHOD

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////SHEMMAR EXPLAIN/////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void BrickDecollision()
        {
            foreach (Control brick in this.Controls)
            {
                if (brick is PictureBox & brick.Tag == "block")
                {
                    if (startofgame == false &&PlayerLives == 0)
                    {
                        Controls.Add(brick);
                    }
                }
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////SHEMMAR EXPLAIN/////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void InvisbleBricks()
        {
            foreach (Control brick in this.Controls)
            {
                if (brick is PictureBox && brick.Tag == "block")
                {
                    brick.Hide();

                }
            }
        }//END OF METHOD

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////SHEMMAR EXPLAIN/////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void VisibleBricks()
        {
            foreach (Control brick in this.Controls)
            {
                if (brick is PictureBox && brick.Tag == "block")
                {
                    brick.Show();
                }
            }
        }//END OF METHOD

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////SHEMMAR EXPLAIN/////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void GameClient_Paint(object sender, PaintEventArgs e)
        {
            if (myGrid != null)
            {
                Graphics g = this.CreateGraphics();
                myGrid.Draw(g, 50, 100);

            }
        }//END OF METHOD


        //METHODS FOR FORM

        //reset the entire game
        void ResetGame()
        {
            
            //Reset the ball
            InvisbleBricks();
            VisibleBricks();
            ResetBall();
            Velocity.X = 0;
            Velocity.Y = 0;

            //Draw ball
            Position += Velocity;
            picBall.Left = (int)Position.X;
            picBall.Top = (int)Position.Y;

            //Reset the player
            //PlayerLives = 3;
            Player = PlayerState.None;
            picPlayer.Left = 368;

            //Reset the labels
            lblLives.Text = "Lives Left: " + PlayerLives;
            lblWelcome.Text = "Welcome!";
            lblBegin.Text = "Please press the SPACEBAR to play.";
            lblForHelp.Text = "For controls and rules of the game,\n              press ''='' at any time.";
            lblTitle.Text = "Breakout Game";
            lblGamePaused.Text = String.Empty;
            lblPressEnter.Text = String.Empty;

            //reset all booleans
            tmrGame.Enabled = false;
            CanSpace = true;
            startofgame = true;
        }//END OF METHOD

        //Method for hidden random facts easter egg
        public void RandomFacts()
        {
            //random facts
            tmrGame.Enabled = false;

            Random RandomFact = new Random();
            for (int i = 0; i < 8; i++)
            {
                Fact[i] = RandomFact.Next(1, 9);
            }

            if (Fact[0] == 0)
            {
                MessageBox.Show("Random Fact #1/8: Banging your head against the wall burns 150 calories per hour.");
            }
            if (Fact[0] == 1)
            {
                MessageBox.Show("Random Fact #2/8: A flock of crows is known as a murder.");
            }
            if (Fact[0] == 2)
            {
                MessageBox.Show("Random Fact #3/8: Catfish are the only animals that naturally have an odd number of whiskers.");
            }
            if (Fact[0] == 3)
            {
                MessageBox.Show("Random Fact #4/8: According to Genesis 1:20-22, the chicken came before the egg.");
            }
            if (Fact[0] == 4)
            {
                MessageBox.Show("Random Fact #5/8: Birds don't urinate.");
            }
            if (Fact[0] == 5)
            {
                MessageBox.Show("Random Fact #6/8: Six is afraid of seven. He said something about seven eating nine.");
            }
            if (Fact[0] == 6)
            {
                MessageBox.Show("Random Fact #7/8: Mel Blanc, the voice of Bugs Bunny, was allergic to carrots.");
            }
            if (Fact[0] == 7)
            {
                MessageBox.Show("Random Fact #8/8: Every year more than 2500 left-handed people are killed from using right-handed products." +
                    "\n...Half of this game's development team is left handed...");
            }

            if (startofgame == true)
            {
                lblPressEnter.Text = "Press SPACEBAR to begin.";
            }
            else
            {
                lblPressEnter.Text = "Press ENTER to continue.";
            }

        }//END OF METHOD

        //Empty methods created by the form
        private void mnuLevels_Click(object sender, EventArgs e)
        {

        }

        private void mnuTutorial_Click(object sender, EventArgs e)
        {

        }

        private void GameClient_Load(object sender, EventArgs e)
        {

        }

    }//End of form
}