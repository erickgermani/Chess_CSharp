using Chess_CSharp.Entities;

namespace Chess_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.Create();
            Match match = new Match(board);
            match.Start();
        }
    }
}