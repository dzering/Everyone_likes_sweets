using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetGame
{
    internal class ProfileGame
    {
        public readonly StateGame currentState;

        public ProfileGame()
        {
            currentState = StateGame.Menu;
        }
        public ProfileGame(StateGame currentState)
        {
            this.currentState = currentState;
        }
    }
}
