using Chess_CSharp.Enums;
using Chess_CSharp.Entities;

namespace Chess_CSharp.Entities.Piece
{
    public class Rook : IPiece
    {
        public Color Color { get; set; }

        public Rook(Color color)
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
            return " R ";
        }
    }
}