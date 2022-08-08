using SweetGame.Utils.Reaction;


namespace SweetGame
{
    internal class ProfileGame
    {
        public readonly SubscriptionProperty<StateGame> state = new SubscriptionProperty<StateGame>();
        public float GameSpeed = 2;

        public ProfileGame()
        {
            state.Value = StateGame.Menu;
            GameSpeed = 2;
        }
    }
}
