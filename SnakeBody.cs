using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

/// <summary>
/// Class for the snake, constructs the body of the snake and 
/// controls its movements.
/// </summary>
/// 
/// <author>
/// Frank Garcia
/// </author>
namespace Snake
{
    /// <summary>
    /// Class for Managing the snake and its segments.
    /// </summary>
    class SnakeBody
    {
        private int n;
        private int capacity;
        private Segment[] body;

        public int Head { get; set; }
        public int Tail { get; set; }


        /// <summary>
        /// Class for managing the snake segments.
        /// </summary>
        public class Segment
        {
            public int Left { get; set; }
            public int Top { get; set; }

            public Segment(Segment seg)
            {
                this.Top = seg.Top;
                this.Left = seg.Left;
            }

            public Segment(int left, int top)
            {
                Left = left;
                Top = top;
            }
        }

        /// <summary>
        /// Constructs the snake's body beginning with the head and 
        /// will construct the body according to the capacity
        /// </summary>
        /// <param name="capacity"> the max size of the snake </param> 
        public SnakeBody(int capacity)
        {
            this.capacity = capacity;
            this.body = new Segment[capacity];

            n = 1;
            Head = 0;
            Tail = 0;

            this.body[0] = new Segment(39, 11);

            for (int i = 1; i < capacity; i++)
            {
                Enqueue(new Segment(body[i-1].Left - 2, body[i-1].Top));
            } 
        }

        /// <summary>
        /// Checks if the snake has run slithered off the edge of the gameboard or
        /// collided with an obstacle.
        /// </summary>
        /// <returns>
        /// if the snake has run off the gameboard or into an obstacle
        /// </returns>
        public bool ValidPosition()
        {
            for (int i = 1; i < capacity; i++)
            {
                if (body[Head].Top == body[i].Top && body[Head].Left == body[i].Left)
                {
                    return false;
                }
            }

            return (body[Head].Top >= 1 && body[Head].Top <= 20 &&
                body[Head].Left >= 5 && body[Head].Left <= 63);

        }

        /// <summary>
        /// Checks if the body is empty.
        /// </summary>
        /// 
        /// <returns>
        /// whether the snake body is empty
        /// </returns>
        public bool Empty()
        {
            return n == 0;
        }

        /// <summary>
        /// Adds a segment to the body of the snake.
        /// </summary>
        /// <param name="b">    the body of the snake </param> 
        public void Enqueue(Segment b)
        {
            Tail = ++Tail % capacity;
            body[Tail] = b;
            if (Empty())
                Head = Tail;

            n++;
        }

        /// <summary>
        /// Returns the value of the Left property of the head of the snake.
        /// </summary>
        /// 
        /// <returns>
        /// the Left property of the head
        /// </returns>
        public int GetHeadXPosition()
        {
            return body[Head].Left;
        }

        /// <summary>
        /// Returns the value of the Top property of the head of the snake.
        /// </summary>
        /// 
        /// <returns>
        /// the Top property of the head
        /// </returns> 
        public int GetHeadYPosition()
        {
            return body[Head].Top;
        }

        /// <summary>
        /// Paints the snake on the board according to its size.
        /// Will paint the head in a separate color.
        /// </summary>
        public void PaintSnake()
        {
            for (int i = 0; i < capacity; i++)
            {
                Console.SetCursorPosition( this.body[i].Left, this.body[i].Top);
                if (i == 0)
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                else
                    Console.BackgroundColor = ConsoleColor.Green;
                
                Console.Write("  ");
                Console.BackgroundColor = ConsoleColor.Black;
            }      
        }

        /// <summary>
        /// Determines the direction the snake will move in and will call the slither
        /// method according to the direction passed into the method.
        /// </summary>
        /// <param name="direction">    direction the snake is moving in </param>    
        public void Move(String direction)
        {
            switch (direction)
            {
                case "up":
                    Slither(0, -1);
                    break;

                case "down":
                    Slither(0, 1);
                    break;

                case "left":
                    Slither(-2, 0);
                    break;

                case "right":
                    Slither(2, 0);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// The snake will slither along the direction the head is moving.
        /// </summary>
        /// <param name="xDirection">   2 for right -2 for left 0 nothing</param>
        /// <param name="yDirection">   1 for down -1 for up 0 nothing</param>
        public void Slither(int xDirection, int yDirection)
        {
            Segment temp = new Segment(body[Head]);

            body[Head].Left += xDirection;
            body[Head].Top += yDirection;

            for (int i = 1; i < capacity; i++)
            {
                Segment temp2;
                temp2 = body[i];
                body[i] = temp;
                temp = temp2;
            }
        }
    }
}
