using System;
using SweetGame.CodeBase.Logic.Animator;
using UnityEngine;

namespace SweetGame.CodeBase.Animators
{
    public class PlayerAnimator : MonoBehaviour, IAnimationStateReader
    {
        public Action<AnimatorState> EnteredAnimation;
        public Action<AnimatorState> ExitedAnimation;

        private Animator _animator;

        private static readonly int IsMove = Animator.StringToHash("isMove");
        private static readonly int Hurt = Animator.StringToHash("hurt");
        private static readonly int Die = Animator.StringToHash("die");

        private readonly int _moveStateHash = Animator.StringToHash("Move");
        private readonly int _hitStateHash = Animator.StringToHash("Hurt");
        private readonly int _dieStateHash = Animator.StringToHash("Die");

        public AnimatorState State { get; private set; }

        private void Awake() =>
            _animator = GetComponent<Animator>();

        public void PlayMove() =>
            _animator.SetBool(IsMove, !_animator.GetBool(IsMove));

        public void PlayHurt() =>
            _animator.SetTrigger(Hurt);

        public void PlayDie() =>
            _animator.SetTrigger(Die);

        public void EnteredState(int hashState)
        {
            State = StateFor(hashState);
            EnteredAnimation?.Invoke(State);
            Debug.Log(State.ToString());
        }

        public void ExitState(int hashState) => 
            ExitedAnimation?.Invoke(State);

        private AnimatorState StateFor(int stateHash)
        {
            AnimatorState state;
            if (stateHash == _moveStateHash)
                state = AnimatorState.Idle;
            else if (stateHash == _hitStateHash)
                state = AnimatorState.Hurt;
            else if (stateHash == _dieStateHash)
                state = AnimatorState.Die;
            else
                state = AnimatorState.None;

            return state;
        }
    }
}