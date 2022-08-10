using SweetGame.Tools.Reaction;
using SweetGame.Game.Sweets;


namespace SweetGame
{
    internal class ProfileGame
    {
        public readonly SubscriptionProperty<StateGame> State = new SubscriptionProperty<StateGame>();
        public SweetType currentPlayer;
        public float GameSpeed = 2;

        public ProfileGame()
        {
            State.Value = StateGame.Menu;
            currentPlayer = 0;
        }
    }
}
