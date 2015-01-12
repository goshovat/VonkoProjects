using System;
using System.Collections.Generic;

namespace FillLabyrinth_BFS
{
    public class Cell
    {
        private int row;
        private int col;
        private string value;

        public Cell(int row, int col, string value)
        {
            this.row = row;
            this.col = col;
            this.value = value;
        }

        public int Row 
        {
            get { return this.row; }
        }

        public int Col
        {
            get { return this.col; }
        }

        public string Value
        {
            get { return this.value; }
        }
    }
}
