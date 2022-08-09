using SweetGame.Tools.Reaction;


namespace SweetGame
{
    internal class ProfileGame
    {
        public readonly SubscriptionProperty<StateGame> State = new SubscriptionProperty<StateGame>();
        public float GameSpeed = 2;

        public ProfileGame()
        {
            State.Value = StateGame.Menu;
        }
    }
}
