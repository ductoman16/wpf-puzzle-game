using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Wpf.PuzzleGame.Core;
using Point = System.Drawing.Point;

namespace Wpf.PuzzleGame.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int SizeX = 8;
        private const int SizeY = 8;

        private Button? _selected;
        private readonly GameBoard _gameBoard;

        public MainWindow()
        {
            InitializeComponent();

            _gameBoard = new GameBoard(SizeX, SizeY);
            _gameBoard.Fill();

            for (var i = 0; i < _gameBoard.Pieces.GetLength(0); i++)
            {
                GameBoardGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (var i = 0; i < _gameBoard.Pieces.GetLength(1); i++)
            {
                GameBoardGrid.RowDefinitions.Add(new RowDefinition());
            }

            RenderBoard(SizeX, SizeY);
        }

        private void RenderBoard(int sizeX, int sizeY)
        {
            GameBoardGrid.Children.Clear();

            var swap1Position = GetSelectedCellPosition();

            for (var x = 0; x < sizeX; x++)
            {
                for (var y = 0; y < sizeY; y++)
                {
                    var color = GetColor(_gameBoard.Pieces[x, y].PieceType);

                    var button = new Button
                    {
                        Width = 50,
                        Height = 50,
                        Background = new SolidColorBrush(color),
                    };

                    if (swap1Position == new Point(x, y))
                    {
                        button.BorderBrush = new SolidColorBrush(Colors.DarkOrange);
                        button.BorderThickness = new Thickness(3);
                    }

                    button.Click += ButtonOnClick;
                    Grid.SetRow(button, y);
                    Grid.SetColumn(button, x);
                    GameBoardGrid.Children.Add(button);
                }
            }
        }

        private void ButtonOnClick(object sender, RoutedEventArgs e)
        {
            if (_selected == null)
            {
                _selected = (Button)sender;
            }
            else
            {
                TrySwap((Button)sender);
            }

            RenderBoard(SizeX, SizeY);
        }

        private void TrySwap(Button sender)
        {
            try
            {
                var first = GetSelectedCellPosition();
                var second = new Point(Grid.GetColumn(sender), Grid.GetRow(sender));
                _gameBoard.Swap(first, second);
                _selected = null;
            }
            catch (InvalidOperationException) { /* Just ignore failed swaps */ }
        }

        private Point GetSelectedCellPosition()
        {
            if (_selected == null)
            {
                return new Point(-1, -1);
            }

            return new Point(Grid.GetColumn(_selected), Grid.GetRow(_selected));
        }

        private static Color GetColor(PieceType pieceType)
        {
            var color = pieceType switch
            {
                PieceType.Circle => Colors.Red,
                PieceType.Square => Colors.Blue,
                PieceType.Diamond => Colors.Yellow,
                PieceType.Hexagon => Colors.Purple,
                PieceType.Star => Colors.White,
                PieceType.Triangle => Colors.Green
            };
            return color;
        }
    }
}
