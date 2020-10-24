using System;
using System.Collections.Generic;
using Chess_CSharp.Entities.Piece;
using Chess_CSharp.Enums;

namespace Chess_CSharp.Entities
{
    public class Board
    {
        public const int BoardLine = 8;
        public const int BoardColumn = 8;
        public List<Position> Position { get; set; } = new List<Position>();

        public void CreateBoard()
        {
            // Lado Preto

            Position.Add(new Position(0, 0, new Rook(Color.Black)));
            Position.Add(new Position(0, 7, new Rook(Color.Black)));
            Position.Add(new Position(0, 1, new Knight(Color.Black)));
            Position.Add(new Position(0, 6, new Knight(Color.Black)));
            Position.Add(new Position(0, 2, new Bishop(Color.Black)));
            Position.Add(new Position(0, 5, new Bishop(Color.Black)));
            Position.Add(new Position(0, 3, new King(Color.Black)));
            Position.Add(new Position(0, 4, new Queen(Color.Black)));
            for(int i = 0; i < 8; i++){
                Position.Add(new Position(1, i, new Pawn(Color.Black)));
            }
            
            // Lado Branco
            Position.Add(new Position(7, 0, new Rook(Color.White)));
            Position.Add(new Position(7, 7, new Rook(Color.White)));
            Position.Add(new Position(7, 1, new Knight(Color.White)));
            Position.Add(new Position(7, 6, new Knight(Color.White)));
            Position.Add(new Position(7, 2, new Bishop(Color.White)));
            Position.Add(new Position(7, 5, new Bishop(Color.White)));
            Position.Add(new Position(7, 3, new King(Color.White)));
            Position.Add(new Position(7, 4, new Queen(Color.White)));
            for(int i = 0; i < 8; i++){
                Position.Add(new Position(6, i, new Pawn(Color.White)));
            }
        }

        public void ShowBoard()
        {
                for(int i = 0; i < BoardLine; i++){
                    if(i == 0){
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("  a  b  c  d  e  f  g  h");
                        Console.ResetColor();
                    }
                    else{
                        Console.WriteLine();
                    }
                    for(int r = 0; r < BoardColumn; r++){
                        bool hasPiece = false;
                        if(r == 0){
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(8 - i);
                            Console.ResetColor();
                        }
                        foreach(Position p in Position){
                            if(p.Line == i && p.Column == r){
                                if(p.Piece.Color == Color.Black){
                                    Console.ForegroundColor = ConsoleColor.Black; 
                                }
                                else{
                                    Console.ForegroundColor = ConsoleColor.White; 
                                }
                                Console.Write(p.Piece.Show());
                                Console.ResetColor();
                                hasPiece = true;
                                break;
                            }
                        }
                        if(hasPiece == false){
                            Console.Write(" - ");
                        }
                }
            }
        }
    }
}