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

        public MainWindow()
        {
            InitializeComponent();
            _board = new Board(Canvas);
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            _board.Add(new Pawn(new Point(0, 1), Side.Black));
            _board.Add(new Pawn(new Point(1, 1), Side.Black));
            _board.Add(new Pawn(new Point(2, 1), Side.Black));
            _board.Add(new Pawn(new Point(3, 1), Side.Black));
            _board.Add(new Pawn(new Point(4, 1), Side.Black));
            _board.Add(new Pawn(new Point(5, 1), Side.Black));
            _board.Add(new Pawn(new Point(6, 1), Side.Black));
            _board.Add(new Pawn(new Point(7, 1), Side.Black));
            _board.Add(new Pawn(new Point(0, 6), Side.White));
            _board.Add(new Pawn(new Point(1, 6), Side.White));
            _board.Add(new Pawn(new Point(2, 6), Side.White));
            _board.Add(new Pawn(new Point(3, 6), Side.White));
            _board.Add(new Pawn(new Point(4, 6), Side.White));
            _board.Add(new Pawn(new Point(5, 6), Side.White));
            _board.Add(new Pawn(new Point(6, 6), Side.White));
            _board.Add(new Pawn(new Point(7, 6), Side.White));


            _board.DrawPieces();
            _board.Select(new Point(5,6));
        }

        private void MainWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            _board.DrawPieces();
        }
        
        private void MainWindow_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            var point = new Point((int)e.GetPosition(Canvas).X/(int)(Canvas.ActualWidth/8), (int)e.GetPosition(Canvas).Y/(int)(Canvas.ActualHeight/8));
            _board.Move(point);
            _board.Select(point);
        }
    }
}