using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CardPickerGame
{
    public class Cell
    {
        //private fields // members //

        private int mSize;
        private int mSize2;
        private int mScore;
        private Color mBackgroundColor;
        private Color mBorderColor;
        private Color mScoreColor;
        private int mColorScore;
        public bool mSelected;


        //Constructor//
        public Cell()
        { // Default cell to whie with black boarder
            this.mSize = 91;
            this.mSize2 = 25;
            this.mBackgroundColor = Color.Tomato;
            this.mBorderColor = Color.Black;
        }

        public Cell(int Size, int Size2, Color BackgroundColor, Color BorderColor)
        {
            this.mSize = Size;
            this.mBackgroundColor = Color.Blue;
            this.mBorderColor = BorderColor;
        }

        //Methods//

        public void Draw(Graphics g, int x, int y)
        {
            //create a pen on to draw with
            Pen BorderPen = new Pen(this.BorderColor);
            SolidBrush BackBrush = new SolidBrush(this.mBackgroundColor);

            //draw cell
            g.FillRectangle(BackBrush, x, y, this.mSize, this.mSize2);
            g.DrawRectangle(BorderPen, x, y, this.mSize, this.mSize2);

            //dispose of drawing objects
            BorderPen.Dispose();
            BackBrush.Dispose();
        }

        //Properties//

        public int Size
        {
            get
            {
                return this.mSize;
            }
            set
            {
                this.mSize = value;
            }
        }
        public int Size2
        {
            get
            {
                return this.mSize2;
            }
            set
            {
                this.mSize2 = value;
            }
        }

        public Color BackgroundColor
        {
            get
            {
                return this.mBackgroundColor;
            }
            set
            {
                this.mBackgroundColor = value;
            }
        }

        public Color BorderColor
        {
            get
            {
                return this.mBorderColor;
            }
            set
            {
                this.mBorderColor = value;
            }
        }
        public int Score
        {
            get
            {
                return mScore;
            }
            set
            {
                this.mScore = value;
            }
        }
    }
}
