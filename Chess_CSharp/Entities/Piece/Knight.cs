using Chess_CSharp.Enums;

namespace Chess_CSharp.Entities.Piece
{
    public class Knight : IPiece
    {
        public string Name { get; set; } = "Knight";

        public Color Color { get; set; }

        public Knight(Color color)
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
            return " H ";
        }
    }
}