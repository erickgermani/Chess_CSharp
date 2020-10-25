using System;
using Chess_CSharp.Enums;

namespace Chess_CSharp.Entities
{
    public class Match
    {
        public Color Turn { get; set; } = Color.White;
        public int Round { get; set; } = 1;
        public Color Winner { get; set; }
        public Board Board { get; set; }

        public Match(Board board)
        {
            Board = board;
        }

        internal void Start()
        {
            while (Winner == Enums.Color.WhithoutWinner)
            {
                Console.WriteLine($"It's the {Round}º round. Turn of: {Turn}");
                Board.Show();
                Console.WriteLine();
                Position position = ReadPiece();
                Action(position);
            }
        }

        public Position ReadPiece()
        {
            Position position = null;
            while (true)
            {
                Console.Write("Which piece do you want to move(Format: a1): ");
                string choice = Console.ReadLine();
                int[] returnedPosition = Board.GetPosition(choice);
                if (returnedPosition.Length == 1)
                {
                    Console.WriteLine("This position not exist.");
                    continue;
                }
                if (Board.VerifyPosition(returnedPosition, Turn))
                {
                    position = Board.Positions.Find(x => x.Line == returnedPosition[0] && x.Column == returnedPosition[1]);
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

        public bool Action(Position position)
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
                int[] returnedPosition = Board.GetPosition(choice);
                if (Board.MovePiece(position, returnedPosition, choice))
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