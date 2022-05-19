using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Chess.Pieces;

namespace Chess;

public class Board
{
    public List<Piece> Boardlist = new();
    private Canvas _canvas;
    private Piece _selected;
    

    public Board(Canvas canvas)
    {
        _canvas = canvas;
    }
    public void Add(Piece piece)
    {
        Boardlist.Add(piece);
    }

    public void Select(Point point)
    {
        _selected = Boardlist.FirstOrDefault(x => x.Position.Equals(point));
        if (_selected == null) return;
        DrawPieces();
        DrawPosibleMoves();
    }

    private void DrawPosibleMoves()
    {
        foreach (var move in _selected.PossibleMoves(this))
        {
            var ellipse = new Ellipse{Fill = Brushes.SpringGreen};
            Canvas.SetLeft(ellipse, _canvas.ActualHeight/8*move.X+10);
            Canvas.SetTop(ellipse, _canvas.ActualWidth/8*move.Y+10);
            ellipse.Height = _canvas.ActualHeight/8-20;
            ellipse.Width = _canvas.ActualWidth/8-20;
            _canvas.Children.Add(ellipse);
        }
    }

    public void DrawPieces()
    {
        _canvas.Children.Clear();
        foreach (var piece in Boardlist)
        {
            piece.Draw(_canvas);
        }
    }

    public void Move(Point point)
    {
        if(_selected == null) return;
        if (_selected.PossibleMoves(this).Any(x => x.Equals(point)))
        {
            Boardlist.Remove(Boardlist.Find(x => x.Position.Equals(point)));
            _selected.Position = point;
        }
        DrawPieces();
    }
}