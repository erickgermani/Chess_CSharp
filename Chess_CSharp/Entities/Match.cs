using System;
using System.Linq;
using Chess_CSharp.Enums;

namespace Chess_CSharp.Entities
{
    public class Match
    {
        public Color Turn { get; set; } = Color.White;
        public int Round { get; set; } = 1;
        public Color Winner { get; set; }

        public Position ReadPiece(Board board)
        {
            Position position = null;
            while (true)
            {
                Console.Write("Which piece do you want to move(Format: a1): ");
                string choice = Console.ReadLine();
                int[] returnedPosition = board.GetPosition(choice);
                if (returnedPosition.Length == 1)
                {
                    Console.WriteLine("This position not exist.");
                    continue;
                }
                if (board.VerifyPosition(returnedPosition, Turn))
                {
                    position = board.Positions.Find(x => x.Line == returnedPosition[0] && x.Column == returnedPosition[1]);
                    break;
                }
                else
                {
                    Console.WriteLine("This position not exist or have no piece in your control.");
                    continue;
                }
            }
            return position;
        }

        public bool Move(Board board, Position position)
        {
            while (true)
            {
                Console.Write("Which position do you want to move to or enter 0 to cancel: ");
                string choice = Console.ReadLine();
                if (choice == "0")
                {
                    Console.Clear();
                    return false;
                }
                int[] returnedPosition = board.GetPosition(choice);
                if (board.Move(position, returnedPosition, choice))
                {
                    NextTurn();
                    return true;
                }
            }
        }

        private void NextTurn()
        {
            if (Turn == Color.White)
            {
                Turn = Color.Black;
            }
            else
            {
                Turn = Color.White;
            }
            Round++;
            Console.Clear();
        }
    }
}