using System.Drawing;
using FluentAssertions;

namespace Wpf.PuzzleGame.Core.Tests.GameBoard;

public class GameBoardTests
{
    private readonly Core.GameBoard _board = new(8,10);

    [Fact]
    public void CanConstructBySize()
    {
        _board.Pieces.GetLength(0).Should().Be(8);
        _board.Pieces.GetLength(1).Should().Be(10);
    }

    [Fact]
    public void CanAccessPiecesByPoint()
    {
        var point = new Point(0, 1);
        var piece = _board[point];

        piece.Should().BeEquivalentTo(_board.Pieces[point.X, point.Y]);
    }
}
