using Chess_CSharp.Enums;
using System.Linq;

namespace Chess_CSharp.Entities.Piece
{
    public class Pawn : IPiece
    {
        public string Name { get; } = "Pawn";

        public Color Color { get; set; }

        public Pawn(Color color)
        {
            Color = color;
        }

        public bool Attack(Board board, Position position, int[] wishedPosition)
        {
            if (wishedPosition[0] == position.Line - 1 || wishedPosition[0] == position.Line + 1)
            {
                if (wishedPosition[1] == position.Column + 1 || wishedPosition[1] == position.Column - 1)
                {
                    if (board.Positions.Any(x => x.Line == wishedPosition[0] && x.Column == wishedPosition[1] && x.Piece.Color != position.Piece.Color))
                    {
                        board.Positions.RemoveAll(x => x.Line == wishedPosition[0] && x.Column == wishedPosition[1]);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Move(Board board, Position position, int[] wishedPosition)
        {
            if (wishedPosition[1] == position.Column)
            {
                if (wishedPosition[0] == position.Line - 1 || wishedPosition[0] == position.Line + 1)
                {
                    if (VerifyPosition(board, position, wishedPosition))
                    {
                        return true;
                    }
                }

                if (wishedPosition[0] == position.Line - 2 || wishedPosition[0] == position.Line + 2)
                {
                    if (position.Line == 6)
                    {
                        wishedPosition[0]++;
                        if (VerifyPosition(board, position, wishedPosition))
                        {
                            wishedPosition[0]--;
                            return true;
                        }
                        wishedPosition[0]--;
                    }
                    if (position.Line == 1)
                    {
                        wishedPosition[0]--;
                        if (VerifyPosition(board, position, wishedPosition))
                        {
                            wishedPosition[0]++;
                            return true;
                        }
                        wishedPosition[0]++;
                    }
                }
            }

            if (Attack(board, position, wishedPosition))
            {
                return true;
            }

            return false;
        }

        public bool VerifyPosition(Board board, Position position, int[] wishedPosition)
        {
            if (board.Positions.Any(x => x.Line == wishedPosition[0] && x.Column == wishedPosition[1]))
            {
                return false;
            }
            return true;
        }

        public string Show()
        {
            return " P ";
        }
    }
}