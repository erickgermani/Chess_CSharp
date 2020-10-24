using System;
using Chess_CSharp.Enums;

namespace Chess_CSharp.Entities
{
    public class Match
    {
        public Color Turn { get; set; } = Color.White;
        public int Round { get; set; } = 1;
        public Color Winner { get; set; }

        public void Action(Board board)
        {
            Position position = null;
            while(true){
                Console.Write("Which piece do you want to move(Format: a1): ");
                string choice = Console.ReadLine();
                int[] returnedPosition = GetPosition(choice);
                if(VerifyPosition(returnedPosition, board, Turn)){
                    foreach(Position b in board.Position){
                        if(b.Line == returnedPosition[0] && b.Column == returnedPosition[1]){
                            position = b;
                            break;
                        }
                    }
                    break;
                }
                else{
                    Console.WriteLine("This position not exist or have no piece in your control.");
                    continue;
                }
            }

            while(true){
                Console.Write("Which position do you want to move to: ");
                string choice = Console.ReadLine();
                int[] returnedPosition = GetPosition(choice);
                if(position.Piece.Move(board, position, returnedPosition)){
                    if(position.Piece.Name == "Pawn"){
                        if(returnedPosition[1] == position.Column - 1 || returnedPosition[1] == position.Column + 1){
                                foreach(Position p in board.Position){
                                    if(p.Line == returnedPosition[0] && p.Column == returnedPosition[1]){
                                        board.Position.Remove(p);
                                        break;
                                    }
                                }
                        }
                        board.Position.Remove(position);
                        board.Position.Add(new Position(returnedPosition[0], returnedPosition[1], position.Piece));
                        board.ShowBoard();
                        break;
                    }
                    board.Position.Remove(position);
                    board.Position.Add(new Position(returnedPosition[0], returnedPosition[1], position.Piece));
                    board.ShowBoard();
                    break;
                }
                else{
                    Console.WriteLine($"The {position.Piece.Name} can't move to {choice}.");
                    continue;
                }
            }

            NextTurn();
        }

        private void NextTurn()
        {
            if(Turn == Color.White){
                Turn = Color.Black;
            }
            else{
                Turn = Color.White;
            }
            Round++;
        }

        public int[] GetPosition(string position){
            int line = 0;
            int column = 0;
            int i = 0;
            foreach (char p in position)
            {
                if(i == 0){
                    switch (p)
                    {
                        case 'a':
                            column = 0;
                            break;
                        case 'b':
                            column = 1;
                            break;
                        case 'c':
                            column = 2;
                            break;
                        case 'd':
                            column = 3;
                            break;
                        case 'e':
                            column = 4;
                            break;
                        case 'f':
                            column = 5;
                            break;
                        case 'g':
                            column = 6;
                            break;
                        case 'h':
                            column = 7;
                            break;
                        default:
                            column = 10;
                            break;
                    }
                }
                else{
                    switch (p)
                    {
                        case '1':
                            line = 7;
                            break;
                        case '2':
                            line = 6;
                            break;
                        case '3':
                            line = 5;
                            break;
                        case '4':
                            line = 4;
                            break;
                        case '5':
                            line = 3;
                            break;
                        case '6':
                            line = 2;
                            break;
                        case '7':
                            line = 1;
                            break;
                        case '8':
                            line = 0;
                            break;
                        default:
                            line = 10;
                            break;
                    }
                }
                i++;
            }

            int[] returnedPosition = new int[2];
            returnedPosition[0] = line;
            returnedPosition[1] = column;

            if(returnedPosition[0] > 7 || returnedPosition[1] > 7){
                int[] error = new int[1];
                error[0] = 0;
                return error;
            }

            else{
                return returnedPosition;
            }
        }
    
        public bool VerifyPosition(int[] position, Board board, Color Turn){
            if(position.Length == 0){
                    return false;
            }

            foreach(Position b in board.Position){
                if(b.Line == position[0] && b.Column == position[1]){
                    if(b.Piece.Color == Turn){
                        return true;
                    }
                }
            }
            return false;
        }
    
    
    }
}