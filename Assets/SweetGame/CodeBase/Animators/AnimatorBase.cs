using UnityEngine;

namespace SweetGame.CodeBase.Animators
{
    public abstract class AnimatorBase : MonoBehaviour
    {
        public abstract void PlayDamage();
        public abstract void PlayDeath();
        public abstract void PlayAttack();
    }
}