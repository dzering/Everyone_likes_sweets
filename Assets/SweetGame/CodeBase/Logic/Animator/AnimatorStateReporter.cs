using UnityEngine;

namespace SweetGame.CodeBase.Logic.Animator
{
    public class AnimatorStateReporter : StateMachineBehaviour
    {
        private IAnimationStateReader _stateReader;

        public override void OnStateEnter(UnityEngine.Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            FindReader(animator);
            
            _stateReader.EnteredState(stateInfo.shortNameHash);
        }

        public override void OnStateExit(UnityEngine.Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            FindReader(animator);
            
            _stateReader.ExitState(stateInfo.shortNameHash);
        }

        private void FindReader(UnityEngine.Animator animator)
        {
            if(_stateReader != null)
                return;

            _stateReader = animator.gameObject.GetComponent<IAnimationStateReader>();
        }
    }
}