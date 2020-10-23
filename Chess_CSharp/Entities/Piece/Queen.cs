using Chess_CSharp.Enums;

namespace Chess_CSharp.Entities.Piece
{
    public class Queen : IPiece
    {

        public Color Color { get; set; }

        public Queen(Color color)
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
            return " Q ";
        }
    }
}