using System;
using UnityEngine;

namespace SweetGame.Enemy
{
    public class Attack : MonoBehaviour
    {
        public EnemyAnimator EnemyAnimator;
        public float CoolDownTime = 3f;
        private Transform _playerTransform;
        private IGameFactory _gameFactory;
        
        private float _coolDownTime;
        private bool _isAttacking;


        private void Awake()
        {
            _gameFactory = AllServices.Container.Single<IGameFactory>();
            _gameFactory.PlayerCreated += OnPlayerCreated;
        }

        private void Update()
        {
            if (CoolDownCheck())
            {
                _coolDownTime -= Time.deltaTime;
                return;
            }
            
            if(!_isAttacking)
               StartAttack();  
        }

        private bool CoolDownCheck()
        {
            return _coolDownTime > 0;
        }

        private void OnAttack(){}

        private void OnAttackEnded()
        {
            _coolDownTime = CoolDownTime;
            _isAttacking = false;
        }

        private void StartAttack()
        {
            _isAttacking = true;
            EnemyAnimator.PlayAttack();
        }

        private void OnPlayerCreated() => 
            _playerTransform = _gameFactory.Player.transform;
    }
}