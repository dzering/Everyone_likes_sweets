using UnityEngine;
using UnityEngine.UI;

namespace SweetGame.CodeBase.UI.Elements
{
    public class HpBar : MonoBehaviour
    {
        public Image HealthBar;

        public void SetValue(float current, float max)
        {
            HealthBar.fillAmount = current / max;
        }
    }
}