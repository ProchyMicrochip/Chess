using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Chess.Figures;

namespace Chess.Pieces;

public abstract class Piece
{
    protected Piece(Side side, Point point, Canvas canvas)
    {
        Side = side;
        _point = point;
        Canvas = canvas;
    }

    protected readonly Canvas Canvas;
    private Point _point;
    public Point Position
    {
        get => _point;
        set
        {
            _point = value;
            Redraw();
        }
    }

    public Side Side { get;}
    public abstract IEnumerable<Point> PossibleMoves(Board board);
    public abstract void Redraw();
    public abstract void Remove();
}