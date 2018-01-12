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
        float Angle;





        //Method for finding a random angle.
        void RandomAngle()
        {
            Random RandomAngle = new Random();

            int r = 0;
            while(r % 2 == 0)
            {
                r = RandomAngle.Next(1, 7);
            }
            Angle = MathHelper.ToRadians(r * 45);

            //video part 4 11mins 10sec in.
        }
    }
}
