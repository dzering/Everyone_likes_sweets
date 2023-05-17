using System;
using System.Collections;
using UnityEngine.SceneManagement;

namespace SweetGame.CodeBase.Infrastructure
{
    public class SceneLoader
    {
        public readonly ICoroutineRunner CoroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner) =>
            CoroutineRunner = coroutineRunner;
    
        public void Load(string name, Action onLoaded = null)
        {
            CoroutineRunner.StartCoroutine(LoadScene(name, onLoaded));
        }
    
        private IEnumerator LoadScene(string nextScene, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoaded?.Invoke();
                yield break;
            }
            var waitNextScene = SceneManager.LoadSceneAsync(nextScene);

            while (!waitNextScene.isDone)
                yield return null;
            
            onLoaded?.Invoke();
        }
    }
}