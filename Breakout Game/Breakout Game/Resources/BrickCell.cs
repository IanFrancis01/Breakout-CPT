using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Breakout_Game.Resources
{
    class BrickCell
    {
        //private fields // members//
        private int mSize;
        private Color mBrickColor;

        
        //Constructor//
        public BrickCell()
        {
            //Default cell to white with black border
            
        } 

        //Properties//
        public int Size
        {
            get{return this.mSize;}
            set {this.mSize = value;}
        }
        public Color BrickColor
        {
            get { return this.mBrickColor; }
            set {this.mBrickColor = value;}
        }
    }
}
