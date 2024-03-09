using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            int column = 10;
            int row = 10;

            List<Snake> snake = new List<Snake>
            {
                new Snake(column / 2, row / 2, column, row)
            };

            new Grid(column, row, snake);

            ConsoleKey keyPressed = ConsoleKey.W;
            bool Continue = true;
            while (Continue)
            {
                ConsoleKeyInfo cki;

                do
                {
                    while (Console.KeyAvailable == false && Continue == true)
                    {
                        Grid.BuildGrid();
                        Thread.Sleep(300); // Loop until input is entered.
                        if (keyPressed == ConsoleKey.W) Continue = Grid.GoUpOrLeft(1, 0);
                        else if (keyPressed == ConsoleKey.A) Continue = Grid.GoUpOrLeft(0, 1);
                        else if (keyPressed == ConsoleKey.S) Continue = Grid.GoDownOrRight(1, 0);
                        else if (keyPressed == ConsoleKey.D) Continue = Grid.GoDownOrRight(0, 1);
                        else Environment.Exit(0);
                    }

                    cki = Console.ReadKey(true);
                    Console.WriteLine("You pressed the '{0}' key.", cki.Key);
                } 
                while (cki.Key != ConsoleKey.A && cki.Key != ConsoleKey.S && cki.Key != ConsoleKey.D && cki.Key != ConsoleKey.W && cki.Key != ConsoleKey.Escape);
                keyPressed = cki.Key;
            }
           
            //bool Continue = true;
            //while (Continue)
            //{
            //    Grid.BuildGrid();
            //    switch (ask("\n\nVil du gå:\nup\ndown\nleft\nright"))
            //    {
            //        case "s":
            //            Continue = Grid.GoDownOrRight(1, 0);
            //            break;
            //        case "w":
            //            Continue = Grid.GoUpOrLeft(1, 0);
            //            break;
            //        case "d":
            //            Continue = Grid.GoDownOrRight(0, 1);
            //            break;
            //        case "a":
            //            Continue = Grid.GoUpOrLeft(0, 1);
            //            break;
            //    }
            //}
        }

        static public string ask(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
    }
}