using Chess_CSharp.Enums;
using Chess_CSharp.Entities;

namespace Chess_CSharp.Entities.Piece
{
    public class Bishop : IPiece
    {
        public string Name { get; } = "Bishop";
        public Color Color { get; set; }

        public Bishop(Color color)
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
            return " B ";
        }
    }
}