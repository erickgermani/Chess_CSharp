using System.Linq;
using Chess_CSharp.Enums;

namespace Chess_CSharp.Entities.Piece
{
    public class Horseman : IPiece
    {
        public string Name { get; } = "Horseman";

        public Color Color { get; set; }

        public Horseman(Color color)
        {
            Color = color;
        }
        public bool Move(Board board, Position position, int[] wishedPosition)
        {
            if(wishedPosition[0] == position.Line + 2 || wishedPosition[0] == position.Line - 2){
                if(wishedPosition[1] == position.Column + 1 || wishedPosition[1] == position.Column - 1){
                    if(VerifyPosition(board, position, wishedPosition)){
                        return true;
                    }
                }
            }
            if(wishedPosition[1] == position.Column + 2 || wishedPosition[1] == position.Column - 2){
                if(wishedPosition[0] == position.Line + 1 || wishedPosition[0] == position.Line - 1){
                    if(VerifyPosition(board, position, wishedPosition)){
                        return true;
                    }
                }
            }
            return false;
        }

        public bool VerifyPosition(Board board, Position position, int[] wishedPosition)
        {
            if(board.Positions.Any(x => x.Line == wishedPosition[0] && x.Column == wishedPosition[1])){
                if(board.Positions.Any(x => x.Line == wishedPosition[0] && x.Column == wishedPosition[1] && x.Piece.Color != position.Piece.Color)){
                    board.Positions.RemoveAll(x => x.Line == wishedPosition[0] && x.Column == wishedPosition[1] && x.Piece.Color != position.Piece.Color);
                    return true;
                }
                return false;
            }
            return true;
        }

        public string Show()
        {
            return " H ";
        }
    }
}