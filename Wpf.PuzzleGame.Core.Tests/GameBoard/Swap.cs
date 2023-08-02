using System.Drawing;

namespace Wpf.PuzzleGame.Core.Tests.GameBoard
{
    public class Swap
    {
        private readonly Core.GameBoard _board = new(3, 3);

        public Swap()
        {
            _board.Fill();
        }

        [Fact]
        public void NotAdjacent_ThrowsException()
        {
            Assert.ThrowsAny<Exception>(() =>
            {
                _board.Swap(new Point(0, 0), new Point(2, 2));
            });
        }

        [Theory]
        [InlineData(0,0, 0,1)]
        [InlineData(0,0, 1,1)]
        [InlineData(0,1, 1,1)]
        [InlineData(1,1, 0,0)]
        [InlineData(1,1, 0,1)]
        [InlineData(1,0, 0,1)]
        public void Adjacent_SwapsPieces(int firstX, int firstY, int secondX, int secondY)
        {
            var first = new Point(firstX, firstY);
            var second = new Point(secondX, secondY);

            var initial1 = _board[first];
            var initial2 = _board[second];

            _board.Swap(first, second);

            var swapped1 = _board[first];
            var swapped2 = _board[second];

            Assert.Equal(initial1, swapped2);
            Assert.Equal(initial2, swapped1);
        }
    }
}
