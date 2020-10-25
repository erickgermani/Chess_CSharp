using Chess_CSharp.Entities;
using System;

namespace Chess_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.CreateBoard();
            Match match = new Match();
            while (match.Winner == Enums.Color.WhithoutWinner)
            {
                Console.WriteLine($"It's the {match.Round}º round. Turn of: {match.Turn}");
                board.ShowBoard();
                Console.WriteLine();
                Position position = match.ReadPiece(board);
                match.Move(board, position);
            }
        }
    }
}