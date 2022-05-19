using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Chess.Figures;

namespace Chess.Pieces;

public abstract class Piece
{
    public Point Position { get; set; }
    public Side Side { get; set; }
    public abstract IEnumerable<Point> PossibleMoves(Board board);
    public abstract void Draw(Canvas canvas);
}