using Chess_CSharp.Enums;

namespace Chess_CSharp.Entities.Piece
{
    public class Knight : IPiece
    {
        public Color Color { get; set; }

        public Knight(Color color)
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
            return " H ";
        }
    }
}