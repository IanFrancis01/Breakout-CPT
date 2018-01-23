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


        //constructors//

        public void DrawBall()
        {
            Position += mVelocity;
            DimensionsX = (int)Position.X;
            DimensionsY = (int)Position.Y;
        }

        public Ball(PictureBox x, int DimensionsX, int DimensionsY)
        {
            this.mDimensionsX = DimensionsX;
            this.mDimensionsY = DimensionsY;
        }

        // methods//
        public float FindRandomAngle()
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

        public void Reset()
        {
            Speed = 6;
            Position = new Vector2((ClientSize.Width - DimensionsX) / 2, (ClientSize.Height - (DimensionsY)));
            float Angle = FindRandomAngle();
            mVelocity = new Vector2((float)(Speed * Math.Cos(Angle)), (float)(Speed * Math.Sin(Angle)));
        }

        //Method for collisions        
        public void Collision()
        {
            //max speed is 11
            if (Speed < 11)
            {
                mVelocity.X *= 1.1f;
                mVelocity.Y *= -1.1f;

                Speed = (float)mVelocity.Length();
            }
            else
            {
                mVelocity.X *= 1;
                mVelocity.Y *= -1;
            }
        }


        //properties//
        public int DimensionsX { get { return this.mDimensionsX; } set { this.mDimensionsX = value; } }
        public int DimensionsY { get { return this.mDimensionsY; } set { this.mDimensionsY = value; } }
        public float Angle { get { return this.mAngle; } set { this.mAngle = value; } }
        public Vector2 Position { get { return this.mPosition; } set { this.mPosition = value; } }


    }
}
