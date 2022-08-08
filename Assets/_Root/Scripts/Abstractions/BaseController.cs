using System;
using System.Collections.Generic;
using UnityEngine;
using SweetGame.Enemy;

namespace SweetGame.Abstractions
{
    internal abstract class BaseController : IDisposable
    {
        private List<IDisposable> controllers;
        private List<GameObject> gameObjects;

        private bool isDispose;

        public void Dispose()
        {
            if (isDispose)
                return;
            DIsposeDisposable();

            DisposeGameObjects();

            OnDispose();

            isDispose = true;
        }
        protected void AddController(IDisposable disposable)
        {
            controllers ??= new List<IDisposable>();
            controllers.Add(disposable);
        }

        protected void AddGameObject(GameObject gameObject)
        {
            gameObjects ??= new List<GameObject>();
            gameObjects.Add(gameObject); 
        }

        protected virtual void OnDispose() { }

        private void DisposeGameObjects()
        {
            if (gameObjects == null)
                return;

            foreach (GameObject gameObject in gameObjects)
                UnityEngine.Object.Destroy(gameObject);

            gameObjects.Clear();
        }

        private void DIsposeDisposable()
        {
            if (controllers == null)
                return;

            foreach (IDisposable disposable in controllers)
                disposable.Dispose();

            controllers.Clear();
        }

    }
}
