using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Chess.Figures;
using Chess.Pieces;

namespace Chess;

public class Board
{
    public readonly ObservableCollection<Piece> Boardlist = new();
    private readonly Canvas _canvas;
    private Piece _selected;
    private List<Ellipse> _possiblemoves = new();

    public Board(Canvas canvas)
    {
        _canvas = canvas;
    }
    
    public void Add(Piece piece)
    {
        Boardlist.Add(piece);
    }

    public void Select(Point point, Side current)
    {
        if(Boardlist.Any(x => x.Position.Equals(point) && x.Side == current))
            _selected = Boardlist.FirstOrDefault(x => x.Position.Equals(point) && x.Side == current);
        if (_selected == null) return;
        DrawPosibleMoves();
    }

    public void Redraw()
    {
        foreach (var piece in Boardlist)
        {
            piece.Redraw();
        }
    }
    private void DrawPosibleMoves()
    {
        if (_possiblemoves != null)
            foreach (var possiblemove in _possiblemoves)
            {
                _canvas.Children.Remove(possiblemove);
            }

        _possiblemoves = _selected?.PossibleMoves(this).Select(x => {  var ellipse = new Ellipse{Fill = Brushes.SpringGreen};
            Canvas.SetLeft(ellipse, _canvas.ActualHeight/8*x.X+10);
            Canvas.SetTop(ellipse, _canvas.ActualWidth/8*x.Y+10);
            ellipse.Height = _canvas.ActualHeight/8-20;
            ellipse.Width = _canvas.ActualWidth/8-20;
            return ellipse;
        }).ToList();
        if (_possiblemoves == null) return;
        {
            foreach (var possiblemove in _possiblemoves)
            {
                _canvas.Children.Add(possiblemove);
            }
        }
    }

    
    
    public bool Move(Point point)
    {
        if(_selected == null) return false;
        if (!_selected.PossibleMoves(this).Any(x => x.Equals(point))) return false;
        {
            var remove = Boardlist.FirstOrDefault(x => x.Position.Equals(point));
            if (remove != null)
            {
                remove.Remove();
                Boardlist.Remove(remove);
            }

            _selected.Position = point;
            _selected = null;
            DrawPosibleMoves();
            return true;
        }
        
    }
}