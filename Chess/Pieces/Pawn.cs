using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Chess.Figures;

namespace Chess.Pieces;

public class Pawn : Piece
{
    private readonly Ellipse _ellipse;
    public Pawn(Point point, Side side)
    {
        Position = point;
        Side = side;
        SolidColorBrush mySolidColorBrush = new SolidColorBrush
        {
            Color = Side == Side.Black ? Colors.Black : Colors.White
        };

        _ellipse = new Ellipse
        {
            Fill = mySolidColorBrush,
            StrokeThickness = 2,
            Stroke = new SolidColorBrush(Side == Side.White ? Colors.Black : Colors.White)
        };
    }
    
    public override IEnumerable<Point> PossibleMoves(Board board)
    {
        //1-up
        IList<Point> moves = new List<Point>();
        var free = !board.Boardlist.Any(x =>
            x.Position.Equals(Point.Add(Position, new Vector(0, Side == Side.Black ? 1 : -1))));
        if (free)
            moves.Add(Point.Add(Position, new Vector(0,Side == Side.Black ? 1 : -1)));
        //2-up
        free = board.Boardlist.Any(x =>
            !x.Position.Equals(Point.Add(Position, new Vector(0, Side == Side.Black ? 2 : -2))) &&
            (int)Position.Y == (Side == Side.Black ? 1 : 6));
        if (free)
            moves.Add(Point.Add(Position, new Vector(0,Side == Side.Black ? 2 : -2)));
        //diagonal-1
        free = board.Boardlist.Any(x =>
            x.Position.Equals(Point.Add(Position, new Vector(1, Side == Side.Black ? 1 : -1)))&& Side != x.Side);
        if(free)
            moves.Add(Point.Add(Position, new Vector(1, Side == Side.Black ? 1 : -1)));
        //diagonal-2
        free = board.Boardlist.Any(x =>
            x.Position.Equals(Point.Add(Position, new Vector(-1, Side == Side.Black ? 1 : -1))) && Side != x.Side);
        if(free)
            moves.Add(Point.Add(Position, new Vector(-1, Side == Side.Black ? 1 : -1)));
        return moves;
    }

    public override void Draw(Canvas canvas)
    {
        Canvas.SetLeft(_ellipse, canvas.ActualHeight/8*Position.X+5);
        Canvas.SetTop(_ellipse, canvas.ActualWidth/8*Position.Y+5);
        _ellipse.Height = canvas.ActualHeight/8-10;
        _ellipse.Width = canvas.ActualWidth/8-10;
        canvas.Children.Add(_ellipse);
    }
}