using Chess_CSharp.Enums;
using System.Linq;

namespace Chess_CSharp.Entities.Piece
{
    public class Pawn : IPiece
    {
        public string Name { get; set; } = "Pawn";

        public Color Color { get; set; }

        public Pawn(Color color)
        {
            Color = color;
        }

        public bool Attack(Board board, Position piecePosition, int[] wishedPosition)
        {
            if (wishedPosition[0] == piecePosition.Line - 1 || wishedPosition[0] == piecePosition.Line + 1)
            {
                if (wishedPosition[1] == piecePosition.Column + 1 || wishedPosition[1] == piecePosition.Column - 1)
                {
                    if (board.Positions.Any(x => x.Line == wishedPosition[0] && x.Column == wishedPosition[1] && x.Piece.Color != piecePosition.Piece.Color))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Move(Board board, Position piecePosition, int[] wishedPosition)
        {
            if (piecePosition.Piece.Color == Color.White)
            {
                if (wishedPosition[1] == piecePosition.Column)
                {
                    if (wishedPosition[0] == piecePosition.Line - 1)
                    {
                        if (VerifyPosition(board, piecePosition, wishedPosition))
                            return true;
                    }

                    if (wishedPosition[0] == piecePosition.Line - 2)
                    {
                        if (piecePosition.Line == 6)
                        {
                            wishedPosition[0]++;
                            if (VerifyPosition(board, piecePosition, wishedPosition))
                            {
                                wishedPosition[0]--;
                                return true;
                            }
                            wishedPosition[0]--;
                        }
                    }
                }
            }
            else
            {
                if (wishedPosition[1] == piecePosition.Column)
                {
                    if (wishedPosition[0] == piecePosition.Line + 1)
                    {
                        if (VerifyPosition(board, piecePosition, wishedPosition))
                            return true;
                    }

                    if (wishedPosition[0] == piecePosition.Line + 2)
                    {
                        if (piecePosition.Line == 1)
                        {
                            wishedPosition[0]--;
                            if (VerifyPosition(board, piecePosition, wishedPosition))
                            {
                                wishedPosition[0]++;
                                return true;
                            }
                            wishedPosition[0]++;
                        }
                    }
                }
            }
            if (Attack(board, piecePosition, wishedPosition))
            {
                return true;
            }
            return false;
        }

        public bool VerifyPosition(Board board, Position piecePosition, int[] wishedPosition)
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