using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_CSharp.Entities
{
    class Board
    {
        public Position Position { get; set; } = new Position();

        public void CreateBoard()
        {
            for (int i = 0; i < Position.Column.Length; i++)
            {
                Console.Write("\n");
                for (int r = 0; r < Position.Line.Length; r++)
                {
                    Console.Write(" - ");
                }
            }
        }
    }
}
