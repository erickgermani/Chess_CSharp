using System;
using System.Collections.Generic;
using System.Text;
using Chess_CSharp.Enums;

namespace Chess_CSharp.Entities
{
    public interface IPiece
    {
        Color Color { get; set; }
        void Move();
        void Destroyed();
        string Show();
        
    }
}
