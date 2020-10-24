using Chess_CSharp.Enums;
using System.Linq;

namespace Chess_CSharp.Entities.Piece
{
    public class Rook : IPiece
    {
        public string Name { get; set; } = "Rook";
        
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

        public bool VerifyPosition(Board board, Position piecePosition, int[] wishedPosition)
        {
            if(wishedPosition[1] == piecePosition.Column && wishedPosition[0] == piecePosition.Line){
                return false;
            }
            if (wishedPosition[1] == piecePosition.Column) {
                if (board.Position.Any(x => (x.Line > piecePosition.Line && x.Line <= wishedPosition[0] && x.Column == wishedPosition[1]) 
                || (x.Line < piecePosition.Line && x.Line >= wishedPosition[0] && x.Column == wishedPosition[1])))
                {
                    if(board.Position.Any(x => x.Line == wishedPosition[0] && x.Column == wishedPosition[1] && x.Piece.Color != piecePosition.Piece.Color)){
                        board.Position.RemoveAll(x => x.Line == wishedPosition[0] && x.Column == wishedPosition[1] && x.Piece.Color != piecePosition.Piece.Color);
                        return true;
                    }
                    return false;
                }
            }
            else{
                if (board.Position.Any(x => (x.Column > piecePosition.Column && x.Column <= wishedPosition[1] && x.Line == wishedPosition[0]) 
                || (x.Column < piecePosition.Column && x.Column >= wishedPosition[1] && x.Column == wishedPosition[0])))
                {
                    if(board.Position.Any(x => x.Line == wishedPosition[0] && x.Column == wishedPosition[1] && x.Piece.Color != piecePosition.Piece.Color)){
                        board.Position.RemoveAll(x => x.Line == wishedPosition[0] && x.Column == wishedPosition[1] && x.Piece.Color != piecePosition.Piece.Color);
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