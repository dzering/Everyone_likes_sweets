using SweetGame.Tools.Reaction;
using SweetGame.Game.Sweets;
using UnityEngine;


namespace SweetGame
{
    public sealed class GameContext : MonoBehaviour
    {
        [HideInInspector] public SubscriptionProperty<StateGame> State;
        [HideInInspector] public SweetType currentPlayer;
        [SerializeField] public float GameSpeed = 2;

        private void Start()
        {
            State = new SubscriptionProperty<StateGame>();
            State.Value = StateGame.Menu;
            currentPlayer = 0;
        }
    }
}
