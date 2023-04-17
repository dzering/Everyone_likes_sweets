using System.Collections;
using UnityEngine;

namespace SweetGame.CodeBase.Logic
{
    public sealed class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _curtain;
        private float _curtainAlpha = 0.06f;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            _curtain.alpha = 1;
        }

        public void Hide() => StartCoroutine(FadeIn());

        private IEnumerator FadeIn()
        {
            while (_curtain.alpha > 0)
            {
                _curtain.alpha -= _curtainAlpha;
                yield return new WaitForSeconds(_curtainAlpha);
            }
        
            gameObject.SetActive(false);
        }
    }
}
