using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Food
    {
        private int _row { get; set; }
        private int _column { get; set; }

        public Food(int row, int column)
        {
            _row = row;
            _column = column;
        }

        public int GetRow() { return _row; }
        public int GetColumn() { return _column; }
    }
}
