using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_CSharp.Entities
{
    class Position
    {
        public string[] Line { get; set; } = new string[8];
        public string[] Column { get; set; } = new string[8];
    }
}
