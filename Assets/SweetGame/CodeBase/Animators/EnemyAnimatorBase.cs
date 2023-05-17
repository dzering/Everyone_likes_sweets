using System;
using SweetGame.CodeBase.Logic.Animator;
using UnityEngine;

namespace SweetGame.CodeBase.Animators
{
    public class EnemyAnimatorBase : AnimatorBase, IAnimationStateReader
    {
        public Action<AnimatorState> EnteredAnimation;
        public Action<AnimatorState> ExitedAnimation;

        private Animator _animator;

        private static readonly int Die = Animator.StringToHash("die");
        private static readonly int Hurt = Animator.StringToHash("hurt");
        private static readonly int TripOver = Animator.StringToHash("tripOver");
        private static readonly int Attack = Animator.StringToHash("attack");
        private static readonly int Idle = Animator.StringToHash("idle");
        private static readonly int IsLookUp = Animator.StringToHash("isLookUp");
        private static readonly int IsRun = Animator.StringToHash("isRun");
        private static readonly int IsJump = Animator.StringToHash("isJump");

        private readonly int _dieStateHash = Animator.StringToHash("Die");
        private readonly int _hurtStateHash = Animator.StringToHash("Hurt");
        private readonly int _tripOverStateHash = Animator.StringToHash("TripOver");
        private readonly int _attackStateHash = Animator.StringToHash("Attack");
        private readonly int _idleStateHash = Animator.StringToHash("Idle");
        private readonly int _isLookUpStateHash = Animator.StringToHash("LookUp");
        private readonly int _isRunStateHash = Animator.StringToHash("Run");
        private readonly int _isJumpStateHash = Animator.StringToHash("Jump");

        private void Awake() => 
            _animator = GetComponent<Animator>();

        public void PlayHurt() =>
            _animator.SetTrigger(Hurt);

        public void PlayTripOver() => 
            _animator.SetTrigger(TripOver);

        public void PlayIdle() => 
            _animator.SetTrigger(Idle);

        public void PlayLookUp() => 
            _animator.SetBool(IsLookUp, !_animator.GetBool(IsLookUp));

        public void PlayRun()
        {
            _animator.SetBool(IsRun, !_animator.GetBool(IsRun));
        }

        public void PlayJump()
        {
            _animator.SetBool(IsJump, !_animator.GetBool(IsJump));
        }

        public void EnteredState(int hashState)
        {
            State = StateFor(hashState);
            EnteredAnimation?.Invoke(State);
            Debug.Log(State.ToString());
        }

        public void ExitState(int hashState)
        {
            ExitedAnimation?.Invoke(State);
        }

        public AnimatorState State { get; private set; }

        private AnimatorState StateFor(int stateHash)
        {
            AnimatorState state;
            if (stateHash == _idleStateHash)
                state = AnimatorState.Idle;
            else if (stateHash == _attackStateHash)
                state = AnimatorState.Attack;
            else if (stateHash == _dieStateHash)
                state = AnimatorState.Die;
            else if (stateHash == _hurtStateHash)
                state = AnimatorState.Hurt;
            else if (stateHash == _isJumpStateHash)
                state = AnimatorState.Jump;
            else if (stateHash == _isRunStateHash)
                state = AnimatorState.Run;
            else if (stateHash == _isLookUpStateHash)
                state = AnimatorState.LookUp;
            else if (stateHash == _tripOverStateHash)
                state = AnimatorState.TripOver;
            else
            {
                state = AnimatorState.None;
            }

            return state;
        }

        public override void PlayDamage() => 
            PlayHurt();

        public override void PlayDeath() => 
            _animator.SetTrigger(Die);

        public override void PlayAttack() => 
            _animator.SetTrigger(Attack);
    }
}