
namespace SweetGame
{
    internal class ProfileGame
    {
        public readonly StateGame currentState;
        public float GameSpeed = 2;

        public ProfileGame()
        {
            currentState = StateGame.Menu;
            GameSpeed = 2;
    }
        public ProfileGame(StateGame currentState)
        {
            this.currentState = currentState;
        }
    }
}
