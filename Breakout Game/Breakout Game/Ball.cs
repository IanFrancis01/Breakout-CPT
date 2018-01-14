using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Drawing;
using System.Windows.Forms;

namespace Breakout_Game
{
    public partial class Ball : Form
    {

        //how much of the code for the ball can we put in a ball class?
        //float speed -
        //vector2 position
        //vector2 velocity
        //collision

        //private fields // members //
        // speed of ball
        float Speed = 6;
        int mDimensionsX;
        int mDimensionsY;
        float mAngle;
        Vector2 mPosition;
        Vector2 mVelocity;
        PictureBox picBall;


        //constructors//

        public void MoveBall()
        {
            Position += mVelocity;
            picBall.Left = (int)Position.X;
            picBall.Top = (int)Position.Y;
        }

        public Ball(PictureBox picBall, int DimensionsX, int DimensionsY, Vector2 Position, Vector2 Velocity, float Angle)
        {
            this.mDimensionsX = DimensionsX;
            this.mDimensionsY = DimensionsY;
            this.mPosition = Position;
            this.mVelocity = Velocity;
            this.mAngle = Angle;


            Position = new Vector2((ClientSize.Width - picBall.Width) / 2, (ClientSize.Height - (picBall.Height * 4)));
            Angle = FindRandomAngle();
            Velocity = new Vector2((float)(Speed * Math.Cos(Angle)), (float)(Speed * Math.Sin(Angle)));

        }

        // methods//
        public static float FindRandomAngle()
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

        void Reset()
        {
            Speed = 6;
            Position = new Vector2((ClientSize.Width - picBall.Width) / 2, (ClientSize.Height - (picBall.Height * 4)));
            float Angle = FindRandomAngle();
            Velocity = new Vector2((float)(Speed * Math.Cos(Angle)), (float)(Speed * Math.Sin(Angle)));
        }


        //properties//
        public int DimensionsX { get { return this.mDimensionsX; } set { this.mDimensionsX = value; } }
        public int DimensionsY { get { return this.mDimensionsY; } set { this.mDimensionsY = value; } }
        public float Angle { get { return this.mAngle; } set { this.mAngle = value; } }
        public Vector2 Position { get { return this.mPosition; } set { this.mPosition = value; } }


    }
}
