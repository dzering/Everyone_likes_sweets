using SweetGame.CodeBase.Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;

namespace SweetGame.CodeBase.UI.Menu
{
    public class SceneButton : MonoBehaviour
    {
        public Button Button;
        public string SceneName;
        private IGameStateMachine StateMachine;

        public void Construct(IGameStateMachine gameStateMachine) => 
            StateMachine = gameStateMachine;

        private void Awake() => 
            OnAwake();

        private void OnAwake() => 
            Button.onClick.AddListener(OpenScene);

        private void OpenScene() =>
            StateMachine.Enter<LoadLevelState, string>(SceneName);
    }
}