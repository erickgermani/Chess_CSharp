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
            board.ShowBoard();
            Console.WriteLine();
            Match match = new Match();
            while(match.Winner == Enums.Color.WhithoutWinner){
                Console.WriteLine();
                match.Action(board);
            }
        }
    }
}
