using System;
using System.Collections.Generic;
using System.Linq;
using Chess_CSharp.Entities.Piece;
using Chess_CSharp.Enums;

namespace Chess_CSharp.Entities
{
    public class Board
    {
        private const int Line = 8;
        private const int Column = 8;
        public List<Position> Positions { get; set; } = new List<Position>();

        public void Create()
        {
            // Lado Preto
            Positions.Add(new Position(0, 0, new Rook(Color.Black)));
            Positions.Add(new Position(0, 7, new Rook(Color.Black)));
            Positions.Add(new Position(0, 1, new Horseman(Color.Black)));
            Positions.Add(new Position(0, 6, new Horseman(Color.Black)));
            Positions.Add(new Position(0, 2, new Bishop(Color.Black)));
            Positions.Add(new Position(0, 5, new Bishop(Color.Black)));
            Positions.Add(new Position(0, 3, new King(Color.Black)));
            Positions.Add(new Position(0, 4, new Queen(Color.Black)));
            for (int i = 0; i < 8; i++)
            {
                Positions.Add(new Position(1, i, new Pawn(Color.Black)));
            }

            // Lado Branco
            Positions.Add(new Position(7, 0, new Rook(Color.White)));
            Positions.Add(new Position(7, 7, new Rook(Color.White)));
            Positions.Add(new Position(7, 1, new Horseman(Color.White)));
            Positions.Add(new Position(7, 6, new Horseman(Color.White)));
            Positions.Add(new Position(7, 2, new Bishop(Color.White)));
            Positions.Add(new Position(7, 5, new Bishop(Color.White)));
            Positions.Add(new Position(7, 3, new King(Color.White)));
            Positions.Add(new Position(7, 4, new Queen(Color.White)));
            for (int i = 0; i < 8; i++)
            {
                Positions.Add(new Position(6, i, new Pawn(Color.White)));
            }
        }

        public void Show()
        {
            for (int i = 0; i < Line; i++)
            {
                if (i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("  a  b  c  d  e  f  g  h");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine();
                }
                for (int r = 0; r < Column; r++)
                {
                    bool hasPiece = false;
                    if (r == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(8 - i);
                        Console.ResetColor();
                    }
                    foreach (Position p in Positions)
                    {
                        if (p.Line == i && p.Column == r)
                        {
                            if (p.Piece.Color == Color.White)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                            }
                            Console.Write(p.Piece.Show());
                            Console.ResetColor();
                            hasPiece = true;
                            break;
                        }
                    }
                    if (!hasPiece)
                    {
                        Console.Write(" - ");
                    }
                }
            }
        }

        public bool MovePiece(Position piecePosition, int[] wishedPosition, string choice)
        {
            if (wishedPosition.Length == 1)
            {
                Console.WriteLine("This position not exist.");
                return false;
            }
            if (piecePosition.Piece.Move(this, piecePosition, wishedPosition))
            {
                this.Positions.Remove(piecePosition);
                this.Positions.Add(new Position(wishedPosition[0], wishedPosition[1], piecePosition.Piece));
                return true;
            }
            Console.WriteLine($"The {piecePosition.Piece.Name} can't move to {choice}.");
            return false;
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
                    column = p switch
                    {
                        'a' => 0,
                        'b' => 1,
                        'c' => 2,
                        'd' => 3,
                        'e' => 4,
                        'f' => 5,
                        'g' => 6,
                        'h' => 7,
                        _ => 10,
                    };
                }
                else
                {
                    line = p switch
                    {
                        '1' => 7,
                        '2' => 6,
                        '3' => 5,
                        '4' => 4,
                        '5' => 3,
                        '6' => 2,
                        '7' => 1,
                        '8' => 0,
                        _ => 10,
                    };
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