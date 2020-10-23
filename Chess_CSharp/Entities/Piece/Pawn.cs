using Chess_CSharp.Enums;

namespace Chess_CSharp.Entities.Piece
{
    public class Pawn : IPiece
    {
        public Color Color { get; set; }

        public Pawn(Color color)
        {
            Color = color;
        }

        public void Destroyed()
        {
            
        }

        public void Move()
        {
            
        }

        public string Show()
        {
            return " P ";
        }
    }
}