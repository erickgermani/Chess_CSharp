using Chess_CSharp.Enums;
using System.Linq;

namespace Chess_CSharp.Entities.Piece
{
    public class Rook : IPiece
    {
        public string Name { get; } = "Rook";
        
        public Color Color { get; set; }

        public Rook(Color color)
        {
            Color = color;
        }

        public bool Move(Board board, Position piecePosition, int[] wishedPosition)
        {
            if(wishedPosition[0] == piecePosition.Line || wishedPosition[1] == piecePosition.Column){
                if(VerifyPosition(board, piecePosition, wishedPosition)){
                    return true;
                }
            }
            return false;
        }

        public bool VerifyPosition(Board board, Position position, int[] wishedPosition)
        {
            if (wishedPosition[1] == position.Column) {
                if (board.Positions.Any(x => (x.Line > position.Line && x.Line <= wishedPosition[0] && x.Column == wishedPosition[1]) 
                || (x.Line < position.Line && x.Line >= wishedPosition[0] && x.Column == wishedPosition[1])))
                {
                    if(board.Positions.Any(x => x.Line == wishedPosition[0] && x.Column == wishedPosition[1] && x.Piece.Color != position.Piece.Color)){
                        board.Positions.RemoveAll(x => x.Line == wishedPosition[0] && x.Column == wishedPosition[1] && x.Piece.Color != position.Piece.Color);
                        return true;
                    }
                    return false;
                }
            }
            if(wishedPosition[0] == position.Line){
                if (board.Positions.Any(x => (x.Column > position.Column && x.Column <= wishedPosition[1] && x.Line == wishedPosition[0]) 
                || (x.Column < position.Column && x.Column >= wishedPosition[1] && x.Column == wishedPosition[0])))
                {
                    if(board.Positions.Any(x => x.Line == wishedPosition[0] && x.Column == wishedPosition[1] && x.Piece.Color != position.Piece.Color)){
                        board.Positions.RemoveAll(x => x.Line == wishedPosition[0] && x.Column == wishedPosition[1] && x.Piece.Color != position.Piece.Color);
                        return true;
                    }
                    return false;
                }
            }
            return true;
        }

        public string Show()
        {
            return " R ";
        }
    }
}