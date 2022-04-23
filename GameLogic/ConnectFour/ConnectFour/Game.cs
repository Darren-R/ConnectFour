
namespace Game
{
    abstract class Game
    {
        protected String IdOne;
        protected String IdTwo;
        protected bool playerOneTurn;
        protected bool computerPlayer;

        public abstract IGameBoards saveGame();
    }
}
