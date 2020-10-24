using System;
using System.Collections.Generic;
using System.Text;
using Chess_CSharp.Enums;

namespace Chess_CSharp.Entities
{
    public interface IPiece
    {
        string Name { get; set; }
        Color Color { get; set; }

        bool Move(Board board, Position position, int[] wishedPosition);
        bool VerifyPosition(Board board, Position position, int[] wishedPosition);
        string Show();
        
    }
}
