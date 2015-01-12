using System;
using System.Collections.Generic;

namespace BombingCuboids
{
    public class Bomb
    {
        private int col;
        private int row;
        private int layer;
        private int power;

        public Bomb(int col, int row, int layer, int power)
        {
            this.col = col;
            this.row = row;
            this.layer = layer;
            this.power = power;
        }

        public int Col 
        {
            get { return this.col; } 
        }
        public int Row 
        {
            get { return this.row; } 
        }
        public int Layer 
        {
            get { return this.layer; }
        }
        public int Power 
        {
            get { return this.power; } 
        }
    }
}
