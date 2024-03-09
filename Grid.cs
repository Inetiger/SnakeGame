using System.Reflection.Metadata.Ecma335;

namespace Snake
{
    internal class Grid
    {
        static private int _column { get; set; }
        static private int _row { get; set; }
        static private List<Snake>? _snake { get; set; }
        static public Food _foodLocation { get; set; }

        static private int _randomRow { get; set; }
        static private int _randomColumn { get; set; }

        static private int _counter { get; set; } = 0;

        public Grid(int column, int row, List<Snake> snake)
        {
            _column = column;
            _row = row;
            _snake = snake;

            _foodLocation = NewRandomFoodLocation();
        }

        static private Food NewRandomFoodLocation()
        {
            Random _random = new Random();
            _randomRow = _random.Next(0, _row);
            _randomColumn = _random.Next(0, _column);

            foreach (var item in _snake)
            {
                if (_randomRow == item.GetRow() && _randomColumn == item.GetColumn())
                {
                    return NewRandomFoodLocation();
                };
            }

            return new Food(_randomRow, _randomColumn);
        }

        static public bool GoDownOrRight(int down, int right)
        {
            for (int i = 0; i < _snake.Count; i++)
            {
                if (_snake[_snake.Count - 1].GetColumn() + right == _snake[i].GetColumn() && _snake[_snake.Count - 1].GetRow() + down == _snake[i].GetRow())
                {
                    return gameOver();
                }
            }
            _snake.Add(new Snake(_snake[_snake.Count - 1].GetColumn() + right, _snake[_snake.Count - 1].GetRow() + down, _column, _row));
            if (_snake[_snake.Count - 1].GetColumn() != _foodLocation.GetColumn() || _snake[_snake.Count - 1].GetRow() != _foodLocation.GetRow())
            {
                _snake.RemoveAt(0);
            }
            else
            {
                _foodLocation = NewRandomFoodLocation();
                _counter++;
            }
            return true;

        }
        static public bool GoUpOrLeft(int up, int left)
        {
            for (int i = 0; i < _snake.Count; i++)
            {
                if (_snake[_snake.Count - 1].GetColumn() - left == _snake[i].GetColumn() && _snake[_snake.Count - 1].GetRow() - up == _snake[i].GetRow())
                {
                    return gameOver();
                }
            }
            _snake.Add(new Snake(_snake[_snake.Count - 1].GetColumn() - left, _snake[_snake.Count - 1].GetRow() - up, _column, _row));
            if (_snake[_snake.Count - 1].GetColumn() != _foodLocation.GetColumn() || _snake[_snake.Count - 1].GetRow() != _foodLocation.GetRow())
            {
                _snake.RemoveAt(0);
            }
            else
            {
                _foodLocation = NewRandomFoodLocation();
                _counter++;
            }
            return true;
        }

        static public bool gameOver()
        {
            Console.Clear();
            Console.WriteLine("Game over");
            return false;
        }

        static public void BuildGrid()
        {
            Console.Clear();

            Console.WriteLine($"\n\nHer er det vi vet:\nFood Row: {_foodLocation.GetRow()}\nFood Column: {_foodLocation.GetColumn()}\nSnake Head Row: {_snake[_snake.Count - 1].GetRow()}\nSnake Head Column: {_snake[_snake.Count - 1].GetColumn()}\n\n");
            Console.WriteLine($"Dette er hvor mange poeng du har: {_counter}");

            //foreach (var snake in _snake)
            //{
            //    Console.WriteLine($"row: {snake.GetRow()} column: {snake.GetColumn()}");
            //}

            for (int i = 0; i < _row; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < _column; j++)
                {
                    bool WasTrue = false;
                    if (i == _foodLocation.GetRow() && j == _foodLocation.GetColumn())
                    {
                        Console.Write("  #");
                        WasTrue = true;
                    }
                    for (int k = 0; k < _snake.Count; k++)
                    {
                        if (i == _snake[k].GetRow() && j == _snake[k].GetColumn())
                        {
                            if (k == _snake.Count - 1) Console.Write("  &");
                            else Console.Write("  o");
                            WasTrue = true;
                        }
                    }
                    if (WasTrue != true) Console.Write("  x");
                }
            }
        }
    }
}
