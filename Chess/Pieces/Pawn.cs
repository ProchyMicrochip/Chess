using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Chess.Figures;
using Point = System.Windows.Point;

namespace Chess.Pieces;

public sealed class Pawn : Piece
{
    private readonly Ellipse _ellipse;
    private readonly TextBlock _textBlock = new(){Text = "P", TextAlignment = TextAlignment.Center};
    public Pawn(Point point, Side side, Canvas canvas) : base(side, point, canvas)
    {
        var mySolidColorBrush = new SolidColorBrush
        {
            Color = Side == Side.Black ? Colors.Black : Colors.White
        };

        _ellipse = new Ellipse
        {
            Fill = mySolidColorBrush,
            StrokeThickness = 2,
            Stroke = new SolidColorBrush(Side == Side.White ? Colors.Black : Colors.White)
        };
        _textBlock.Foreground = Side == Side.White ? Brushes.Black : Brushes.White; 
        Redraw();
        Draw();
    }
    
    public override IEnumerable<Point> PossibleMoves(Board board)
    {
        
        IList<Point> moves = new List<Point>();
        //diagonal-1
        var free = board.Boardlist.Any(x =>
            x.Position.Equals(Point.Add(Position, new Vector(1, Side == Side.Black ? 1 : -1)))&& Side != x.Side);
        if(free)
            moves.Add(Point.Add(Position, new Vector(1, Side == Side.Black ? 1 : -1)));
        //diagonal-2
        free = board.Boardlist.Any(x =>
            x.Position.Equals(Point.Add(Position, new Vector(-1, Side == Side.Black ? 1 : -1))) && Side != x.Side);
        if(free)
            moves.Add(Point.Add(Position, new Vector(-1, Side == Side.Black ? 1 : -1)));
        //1-up
        free = !board.Boardlist.Any(x =>
            x.Position.Equals(Point.Add(Position, new Vector(0, Side == Side.Black ? 1 : -1))));
        if (free)
            moves.Add(Point.Add(Position, new Vector(0,Side == Side.Black ? 1 : -1)));
        else
        {
            return moves;
        }
        //2-up
        free = !board.Boardlist.Any(x =>
            x.Position.Equals(Point.Add(Position, new Vector(0, Side == Side.Black ? 2 : -2))) ||
            (int)Position.Y != (Side == Side.Black ? 1 : 6));
        if (free)
            moves.Add(Point.Add(Position, new Vector(0,Side == Side.Black ? 2 : -2)));
        
        return moves.Where(x => x.Y is < 8 and >= 0 && x.X is < 8 and >= 0);
    }

    public override void Redraw()
    {
        Canvas.SetLeft(_ellipse, Canvas.ActualHeight/8*Position.X+5);
        Canvas.SetTop(_ellipse, Canvas.ActualWidth/8*Position.Y+5);
        _ellipse.Height = Canvas.ActualHeight/8-10;
        _ellipse.Width = Canvas.ActualWidth/8-10;
        Canvas.SetLeft(_textBlock, Canvas.ActualHeight/8*Position.X+5);
        Canvas.SetTop(_textBlock, Canvas.ActualWidth/8*Position.Y+5);
        _textBlock.Height = Canvas.ActualHeight/8-10;
        _textBlock.Width = Canvas.ActualWidth/8-10;
        _textBlock.FontSize = Canvas.ActualHeight/16;
        //_textBlock.Background = Brushes.Blue;
    }

    private void Draw()
    {
        Canvas.Children.Add(_ellipse);
        Canvas.Children.Add(_textBlock);
    }

    public override void Remove()
    {
        Canvas.Children.Remove(_ellipse);
        Canvas.Children.Remove(_textBlock);
    }
    
}