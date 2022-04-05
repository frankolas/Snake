using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Generates the obstacles and gives them random coordinates on the board
/// to challenge the player throughout gameplay.
/// </summary>
/// 
/// <author>
/// Frank Garcia
/// </author>
namespace Snake
{
    class Obstacle
    {
        private SnakeBody snake;
        public int Top { get; set; }
        public int Left { get; set; }

        /// <summary>
        /// Constructs the obstacle that will be positioned at a random Top and Left value.
        /// </summary>
        /// <param name="width">Width of the GameBoard so the RNG knows the bounds for the obstacle</param>
        /// <param name="height">Width of the GameBoard so the RNG knows the bounds for the obstacle</param>
        public Obstacle(SnakeBody s, int width, int height)
        {
            snake = s;
            Random rand = new Random();
            ChangeCoords(width, height);
        }

        /// <summary>
        /// Changes the coordinates of the obstacle and assigns the obstacle
        /// a new Top and Left value.
        /// </summary>
        /// <param name="width">width of the board for the rng</param>
        /// <param name="height">height of the board for the rng</param>
        public void ChangeCoords(int width, int height)
        {
            Random rand = new Random();
            Top = rand.Next(2, height);
            Left = rand.Next(6, width);
            while (Left % 2 == 0)
            {
                Left = rand.Next(30, width);
            }
        }

        /// <summary>
        /// Paints the obstacle in a random position on the board.
        /// </summary>
        public void PaintObstacle()
        {
            Console.CursorTop = Top;
            Console.CursorLeft = Left;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
