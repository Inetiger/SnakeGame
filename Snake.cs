
namespace Snake
{
    internal class Snake
    {
        private int _column { get; set; }
        private int _row { get; set; }
        private int _maxColumn { get; set; }
        private int _maxRow { get; set; }

        public Snake(int column, int row, int maxColumn, int maxRow)
        {
            _column = column;
            _row = row;
            _maxColumn = maxColumn;
            _maxRow = maxRow;

            if (_column >= _maxColumn) _column = 0;
            if (_row >= _maxRow) _row = 0; 
            if (_column < 0) _column = _maxColumn - 1;
            if (_row < 0) _row = _maxRow - 1;

            //Console.WriteLine($"Row: {_row} \nColumn: {_column}");
        }

        public int GetRow()
        {
            return _row;
        }
        public int GetColumn()
        {
            return _column;
        }
        public void showCoordinates()
        {
            Console.WriteLine(_column);
            Console.WriteLine(_row);
        }
    }
}
