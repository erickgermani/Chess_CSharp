using Chess_CSharp.Enums;

namespace Chess_CSharp.Entities.Piece
{
    public class King : IPiece
    {
        public Color Color { get; set; }

        public King(Color color)
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
            return " K ";
        }
    }
}