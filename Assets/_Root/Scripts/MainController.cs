using SweetGame.Abstractions;

namespace SweetGame
{
    internal class MainController : BaseController
    {
        private ProfileGame profileGame;
        public MainController(ProfileGame profileGame)
        {
            this.profileGame = profileGame;
            profileGame.state.SubscribeOnChange(ChooseGameState);
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            profileGame.state.UnsubscribeOnChange(ChooseGameState);
        }

        private void ChooseGameState(StateGame stateGame)
        {
            switch (stateGame)
            {
                case StateGame.None:
                    break;
                case StateGame.Menu:
                    break;
                case StateGame.Game:
                    break;
                default:
                    break;
            }
        }
    }
}