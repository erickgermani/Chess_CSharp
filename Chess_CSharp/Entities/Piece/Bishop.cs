using Chess_CSharp.Enums;
using Chess_CSharp.Entities;

namespace Chess_CSharp.Entities.Piece
{
    public class Bishop : IPiece
    {
        public Color Color { get; set; }

        public Bishop(Color color)
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
            return " B ";
        }
    }
}