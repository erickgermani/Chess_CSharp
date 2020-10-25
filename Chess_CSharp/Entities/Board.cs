using System;
using System.Collections.Generic;
using System.Linq;
using Chess_CSharp.Entities.Piece;
using Chess_CSharp.Enums;

namespace Chess_CSharp.Entities
{
    public class Board
    {
        public const int Line = 8;
        public const int Column = 8;
        public List<Position> Positions { get; set; } = new List<Position>();

        public bool Move(Position position, int[] wishedPosition, string choice){
                if (wishedPosition.Length == 1)
                {
                    Console.WriteLine("This position not exist.");
                    return false;
                }
                if (position.Piece.Move(this, position, wishedPosition))
                {
                    if (position.Piece.Name == "Pawn")
                    {
                        if (wishedPosition[1] == position.Column - 1 || wishedPosition[1] == position.Column + 1)
                        {
                            this.Positions.RemoveAll(x => x.Line == wishedPosition[0] && x.Column == wishedPosition[1]);
                        }
                        this.Positions.Remove(position);
                        this.Positions.Add(new Position(wishedPosition[0], wishedPosition[1], position.Piece));
                        return true;
                    }
                    this.Positions.Remove(position);
                    this.Positions.Add(new Position(wishedPosition[0], wishedPosition[1], position.Piece));
                    return true;
                }
                else
                {
                    Console.WriteLine($"The {position.Piece.Name} can't move to {choice}.");
                    return false;
                }
        }
        public void CreateBoard()
        {
            // Lado Preto
            Positions.Add(new Position(0, 0, new Rook(Color.Black)));
            Positions.Add(new Position(0, 7, new Rook(Color.Black)));
            Positions.Add(new Position(0, 1, new Knight(Color.Black)));
            Positions.Add(new Position(0, 6, new Knight(Color.Black)));
            Positions.Add(new Position(0, 2, new Bishop(Color.Black)));
            Positions.Add(new Position(0, 5, new Bishop(Color.Black)));
            Positions.Add(new Position(0, 3, new King(Color.Black)));
            Positions.Add(new Position(0, 4, new Queen(Color.Black)));
            for(int i = 0; i < 8; i++){
                Positions.Add(new Position(1, i, new Pawn(Color.Black)));
            }
            
            // Lado Branco
            Positions.Add(new Position(7, 0, new Rook(Color.White)));
            Positions.Add(new Position(7, 7, new Rook(Color.White)));
            Positions.Add(new Position(7, 1, new Knight(Color.White)));
            Positions.Add(new Position(7, 6, new Knight(Color.White)));
            Positions.Add(new Position(7, 2, new Bishop(Color.White)));
            Positions.Add(new Position(7, 5, new Bishop(Color.White)));
            Positions.Add(new Position(7, 3, new King(Color.White)));
            Positions.Add(new Position(7, 4, new Queen(Color.White)));
            for(int i = 0; i < 8; i++){
                Positions.Add(new Position(6, i, new Pawn(Color.White)));
            }
        }

        public void ShowBoard()
        {
                for(int i = 0; i < Line; i++){
                    if(i == 0){
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("  a  b  c  d  e  f  g  h");
                        Console.ResetColor();
                    }
                    else{
                        Console.WriteLine();
                    }
                    for(int r = 0; r < Column; r++){
                        bool hasPiece = false;
                        if(r == 0){
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(8 - i);
                            Console.ResetColor();
                        }
                        foreach(Position p in Positions){
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

        public int[] GetPosition(string position)
        {
            int[] error = new int[1] { 0 };

            if (position.Length != 2)
            {
                return error;
            }
            int line = 0;
            int column = 0;
            int i = 0;
            foreach (char p in position)
            {
                if (i == 0)
                {
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
                else
                {
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

            int[] wishedPosition = new int[2];
            wishedPosition[0] = line;
            wishedPosition[1] = column;

            if (wishedPosition[0] > 7 || wishedPosition[1] > 7)
            {
                return error;
            }

            else
            {
                return wishedPosition;
            }
        }

        public bool VerifyPosition(int[] position, Color Turn)
        {
            if (this.Positions.Any(p => p.Line == position[0] && p.Column == position[1] && p.Piece.Color == Turn))
            {
                return true;
            }
            return false;
        }
    }
}