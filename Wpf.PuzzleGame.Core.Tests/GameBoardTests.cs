using FluentAssertions;

namespace Wpf.PuzzleGame.Core.Tests;

public class GameBoardTests
{
    private readonly GameBoard _board = new(8, 8);

    [Fact]
    public void CanConstructBySize()
    {
        var board = new GameBoard(8,10);

        board.Pieces.GetLength(0).Should().Be(8);
        board.Pieces.GetLength(1).Should().Be(10);
    }

    [Fact]
    public void Pieces_CanAccessByCoordinates()
    {
        // Doesn't throw exception
        var piece = _board.Pieces[0, 0];
    }

    [Fact]
    public void Pieces_BeforeFilling_AreNull()
    {
        var piece = _board.Pieces[0, 0];

        piece.Should().BeNull();
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(0, 1)]
    public void Pieces_AfterFilling_NotNull(int xPos, int yPos)
    {
        _board.Fill();
        
        var piece = _board.Pieces[xPos, yPos];

        piece.Should().NotBeNull();
    }


}
