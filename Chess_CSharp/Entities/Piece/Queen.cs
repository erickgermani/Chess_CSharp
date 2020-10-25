using Chess_CSharp.Enums;

namespace Chess_CSharp.Entities.Piece
{
    public class Queen : IPiece
    {
        public string Name { get; } = "Queen";

        public Color Color { get; set; }

        public Queen(Color color)
        {
            Color = color;
        }

        public bool Move(Board board, Position position, int[] wishedPosition)
        {
            return false;
        }

        public bool VerifyPosition(Board board, Position position, int[] wishedPosition)
        {
            return false;
        }

        public string Show()
        {
            return " Q ";
        }
    }
}