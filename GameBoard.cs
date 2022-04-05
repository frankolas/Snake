using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Class that will serve as the board the snake gameplay
/// takes place on.
/// </summary>
/// 
/// <author>
/// Frank Garcia
/// </author>
namespace Snake
{
    class GameBoard
    {
        public int Width { get; }
        public int Height { get; }

        /// <summary>
        /// Constructs the board on the screen.
        /// </summary>
        /// <param name="width"></param> the width of the board
        /// <param name="height"></param> the height of the board
        public GameBoard(int width, int height)
        {
            if (width % 2 == 1)
                throw new InvalidOperationException("Width must be even");

            this.Width = width;
            this.Height = height;

            
        }

        /// <summary>
        /// Paints the board to the screen and will write the title above the board.
        /// </summary>
        public void PaintBoard()
        {
            Console.SetCursorPosition(5, 0);
            Console.WriteLine("S N A K E");
            Console.CursorTop = 1;
            Console.BackgroundColor = ConsoleColor.DarkGray;

            for (int i = 0; i < Height; i++)
            {
                Console.CursorLeft = 5;
                Console.WriteLine(new string(' ', Width));
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// Erases the board from the screan and resets the screen to black.
        /// </summary>
        public void EraseBoard()
        {
            Console.SetCursorPosition(5, 0);
            Console.WriteLine("S N A K E");
            Console.CursorTop = 1;
            Console.BackgroundColor = ConsoleColor.Black;

            for (int i = 0; i < Height; i++)
            {
                Console.CursorLeft = 5;
                Console.WriteLine(new string(' ', Width));
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
