namespace SweetGame
{
    internal class MainController
    {
        private ProfileGame profileGame;
        public MainController(ProfileGame profileGame)
        {
            this.profileGame = profileGame;
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