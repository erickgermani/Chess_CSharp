using Chess_CSharp.Enums;

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

        public bool Attack(Board board, Position piecePosition, int[] wishedPosition){
            if (piecePosition.Piece.Color == Color.White)
            {
                if (wishedPosition[0] == piecePosition.Line - 1)
                {
                    if (wishedPosition[1] == piecePosition.Column + 1 || wishedPosition[1] == piecePosition.Column - 1)
                    {
                        foreach(Position position in board.Position){
                            if(wishedPosition[0] == position.Line && wishedPosition[1] == position.Column && position.Piece.Color == Color.Black){
                                return true;
                            }
                        }
                    }
                }
            }
            else
            {
                if (wishedPosition[0] == piecePosition.Line + 1)
                {
                    if (wishedPosition[1] == piecePosition.Column + 1 || wishedPosition[1] == piecePosition.Column - 1)
                    {
                        foreach(Position position in board.Position){
                            if(wishedPosition[0] == position.Line && wishedPosition[1] == position.Column && position.Piece.Color == Color.White){
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public bool Move(Board board, Position piecePosition, int[] wishedPosition)
        {
            if(piecePosition.Piece.Color == Color.White){
                if (wishedPosition[1] == piecePosition.Column)
                {
                    if (piecePosition.Line == 6)
                    {
                        if (wishedPosition[0] == piecePosition.Line - 1 || wishedPosition[0] == piecePosition.Line - 2)
                        {
                            if (VerifyPosition(board, piecePosition, wishedPosition))
                                return true;
                        }
                    }
                    else
                    {
                        if (wishedPosition[0] == piecePosition.Line - 1)
                        {
                            if (VerifyPosition(board, piecePosition, wishedPosition))
                                return true;
                        }
                    }
                }
            }
            else{
                if(wishedPosition[1] == piecePosition.Column){
                    if(piecePosition.Line == 1)
                    {
                        if(wishedPosition[0] == piecePosition.Line + 1 || wishedPosition[0] == piecePosition.Line + 2)
                        {
                            if(VerifyPosition(board, piecePosition, wishedPosition))
                                return true;
                        }
                    }
                    else{
                        if(wishedPosition[0] == piecePosition.Line + 1){
                            if(VerifyPosition(board, piecePosition, wishedPosition))
                                return true;
                        }
                    }
                }
            }
            if(Attack(board, piecePosition, wishedPosition)){
                return true;
            }
            return false;
        }

        public bool VerifyPosition(Board board, Position piecePosition, int[] wishedPosition)
        {
            foreach(Position position in board.Position){
                if(wishedPosition[0] == position.Line && wishedPosition[1] == position.Column){
                    return false;
                }
            }
            return true;
        }

        public string Show()
        {
            return " P ";
        }
    }
}