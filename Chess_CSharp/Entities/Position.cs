using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_CSharp.Entities
{
    public class Position
    {
        public int Line { get; set; }
        public int Column { get; set; }
        public IPiece Piece { get; set; }

        public Position(int line, int column, IPiece piece)
        {
            Line = line;
            Column = column;
            Piece = piece;
        }

    }
}
