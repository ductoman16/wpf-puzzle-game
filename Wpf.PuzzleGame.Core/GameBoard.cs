namespace Wpf.PuzzleGame.Core;
public class GameBoard
{
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
                Pieces[x, y] = new Piece();
            }
        }
    }
}