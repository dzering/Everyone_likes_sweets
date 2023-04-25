using System;
using SweetGame.CodeBase.Data;
using SweetGame.CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.UI;

namespace SweetGame.CodeBase.UI.Windows
{
    public abstract class WindowBase : MonoBehaviour
    {
        public Button CloseButton;
        protected IProgressService ProgressService;
        protected PlayerProgress PlayerProgress => ProgressService.PlayerProgress;

        public void Construct(IProgressService progressService)
        {
            ProgressService = progressService;
        }
        private void Awake() => 
            OnAwake();

        private void Start()
        {
            Initialize();
            SubscribeUpdate();
        }

        private void OnDestroy()
        {
            CleanUp();
        }

        protected virtual void OnAwake() => 
            CloseButton.onClick.AddListener(()=>Destroy(gameObject));

        protected virtual void CleanUp(){}
        protected virtual void SubscribeUpdate(){}
        protected virtual void Initialize(){}
    }
}