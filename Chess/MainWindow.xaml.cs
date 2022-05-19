using System;
using System.Windows;
using System.Windows.Input;
using Chess.Figures;
using Chess.Pieces;

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly Board _board;
        private Side _current = Side.White;
        public MainWindow()
        {
            InitializeComponent();
            _board = new Board(Canvas);
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            _board.Add(new Pawn(new Point(0, 1), Side.Black,Canvas));
            _board.Add(new Pawn(new Point(1, 1), Side.Black,Canvas));
            _board.Add(new Pawn(new Point(2, 1), Side.Black,Canvas));
            _board.Add(new Pawn(new Point(3, 1), Side.Black,Canvas));
            _board.Add(new Pawn(new Point(4, 1), Side.Black,Canvas));
            _board.Add(new Pawn(new Point(5, 1), Side.Black,Canvas));
            _board.Add(new Pawn(new Point(6, 1), Side.Black,Canvas));
            _board.Add(new Pawn(new Point(7, 1), Side.Black,Canvas));
            _board.Add(new Pawn(new Point(0, 6), Side.White,Canvas));
            _board.Add(new Pawn(new Point(1, 6), Side.White,Canvas));
            _board.Add(new Pawn(new Point(2, 6), Side.White,Canvas));
            _board.Add(new Pawn(new Point(3, 6), Side.White,Canvas));
            _board.Add(new Pawn(new Point(4, 6), Side.White,Canvas));
            _board.Add(new Pawn(new Point(5, 6), Side.White,Canvas));
            _board.Add(new Pawn(new Point(6, 6), Side.White,Canvas));
            _board.Add(new Pawn(new Point(7, 6), Side.White, Canvas));
            _board.Add(new Knight(new Point(1,0),Side.Black,Canvas));
            _board.Add(new Knight(new Point(6,0),Side.Black,Canvas));
            _board.Add(new Knight(new Point(1,7),Side.White,Canvas));
            _board.Add(new Knight(new Point(6,7),Side.White,Canvas));
            _board.Add(new King(new Point(4,0),Side.Black,Canvas));
            _board.Add(new King(new Point(4,7),Side.White,Canvas));
            _board.Add(new Queen(new Point(3,0),Side.Black,Canvas));
            _board.Add(new Queen(new Point(3,7),Side.White,Canvas));
            _board.Add(new Rook(new Point(0,0),Side.Black,Canvas));
            _board.Add(new Rook(new Point(7,0),Side.Black,Canvas));
            _board.Add(new Rook(new Point(0,7),Side.White,Canvas));
            _board.Add(new Rook(new Point(7,7),Side.White,Canvas));
            _board.Add(new Bishop(new Point(2,0),Side.Black,Canvas));
            _board.Add(new Bishop(new Point(5,0),Side.Black,Canvas));
            _board.Add(new Bishop(new Point(2,7),Side.White,Canvas));
            _board.Add(new Bishop(new Point(5,7),Side.White,Canvas));
            
        }

        private void MainWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            _board.Redraw();
        }
        
        private void MainWindow_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            var point = new Point((int)e.GetPosition(Canvas).X/(int)(Canvas.ActualWidth/8), (int)e.GetPosition(Canvas).Y/(int)(Canvas.ActualHeight/8));
            if(_board.Move(point)) _current = _current == Side.White? Side.Black : Side.White;
            _board.Select(point,_current);
            
        }
    }
}