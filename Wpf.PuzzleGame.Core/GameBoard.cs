using System.Drawing;

namespace Wpf.PuzzleGame.Core;
public class GameBoard
{
    private readonly Random _random = new();
    private readonly PieceType[] _types = Enum.GetValues<PieceType>();

    public GameBoard(int sizeX, int sizeY)
    {
        Pieces = new Piece[sizeX, sizeY];
    }

    public Piece[,] Pieces { get; }

    public void Fill()
    {
        for (var x = 0; x < Pieces.GetLength(0); x++)
        {
            for (var y = 0; y < Pieces.GetLength(0); y++)
            {
                var type = _types.GetValue(_random.Next(_types.Length)) as PieceType?;
                Pieces[x, y] = new Piece(type ?? throw new InvalidOperationException("Generated null piece."));
            }
        }
    }

    public void Swap(Point first, Point second)
    {
        var isXAdjacent = Math.Abs(first.X - second.X) <= 1;
        var isYAdjacent = Math.Abs(first.Y - second.Y) <= 1;

        if (!isXAdjacent || !isYAdjacent)
        {
            throw new InvalidOperationException();
        }

        (this[first], this[second]) = (this[second], this[first]);
    }

    public Piece this[Point point]
    {
        get => Pieces[point.X, point.Y];
        set => Pieces[point.X, point.Y] = value;
    }
}