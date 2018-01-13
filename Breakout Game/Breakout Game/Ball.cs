using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Breakout_Game
{
    class Ball
    {
        //how much of the code for the ball can we put in a ball class?
        //float speed -
        //vector2 position
        //vector2 velocity
        //collision

        //private fields // members //
        // speed of ball
        float speed;
        int mDimensions;
        Vector2 mPosition;
        Vector2 mVelocity;

        //constructors//
        public Ball()
        {
            this.mDimensions = 25;
            this.mPosition = ;
        }
        public Ball(int Dimensions, Vector2 Position, Vector2 Velocity)
        {
            this.mDimensions = Dimensions;
            this.mPosition = Position;
            this.mVelocity = Velocity;
        }
        //properties//
        public int Dimensions { get { return this.mDimensions; } set { this.mDimensions = value; } }
        public Vector2 Position { get { return this.mPosition; } set { this.mPosition = value; } }
        public Vector2 Velocity { get { return this.mVelocity; } set { this.mVelocity = value; } }

    }
}
