using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CardPickerGame
{
    public class Grid
    {
        //private fields // members//
        private Cell[,] mGrid;
        private int mRows, mColumns;
        private int mCellSize;

        //constructors//
        public Grid(int Rows, int Columns, int CellSize)
        {
            //stores rows, columns, and cell sizes//
            this.mRows = Rows;
            this.mColumns = Columns;
            this.mCellSize = CellSize;
            //set the grid size in memory

            mGrid = new Cell[this.mRows, this.mColumns];
            Random ColourSwap = new Random();




            //create each cell in the array
            for (int i = 0; i < this.mRows; i++)
            {
                for (int j = 0; j < this.mColumns; j++)
                {
                    mGrid[i, j] = new Cell();
                }
            }
        }


        //methods//
        public Cell GetCell(int Row, int Column)
        {
            return mGrid[Row, Column];
        }

        public void Draw(Graphics g, int x, int y)
        {


            int px = x;
            int py = y;

            for (int i = 0; i < this.mRows; i++)
            {
                py = y + (i * 30);
                for (int j = 0; j < this.mColumns; j++)
                {
                    px = x + (j * 95);
                    mGrid[i, j].Draw(g, px, py);

                }

            }
        }


        public Color temp { get; set; }
    }
}
