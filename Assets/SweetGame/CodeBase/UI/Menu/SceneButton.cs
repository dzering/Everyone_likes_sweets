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

        private void OpenScene()
        {
            OpenScene(SceneName);
            //StateMachine.Enter<LoadLevelState, string>(SceneName);
        }

        private void OpenScene(string sceneName)
        {
            switch (sceneName)
            {
                case "Main": 
                    StateMachine.Enter<LoadLevelState, string>(SceneName);
                    break;
                case "Menu": 
                    StateMachine.Enter<LoadMenuState, string>(SceneName);
                    break;
                default:
                    break;
            }
        }
    }
}