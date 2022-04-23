
namespace Game
{
    public interface IGameBoards
    {
        public bool winCondition(int columnsPlaced, string playerPlacing);
        public bool placePiece(int columnsPlaced, string playerPlacing);
        public void printBoard();

    }
}
