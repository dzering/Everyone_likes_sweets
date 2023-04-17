using System.Linq;
using SweetGame.CodeBase.Animators;
using SweetGame.CodeBase.Game.Player;
using SweetGame.CodeBase.Infrastructure.Factory;
using SweetGame.CodeBase.Infrastructure.Services;
using SweetGame.CodeBase.Utils;
using UnityEngine;

namespace SweetGame.CodeBase.Game.Enemy
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private float _effectiveDistance = 2f;
        public EnemyAnimator EnemyAnimator;
        public float CoolDownTime = 3f;
        public float Damage = 10f;
        
        private Transform _playerTransform;
        private IGameFactory _gameFactory;

        private float _coolDownTime;
        private bool _isAttacking;
        private int _layerMask;
        private readonly Collider2D[] _hits = new Collider2D[1];
        private float Radius = 1f;
        private bool _attackIsActive;


        private void Awake()
        {
            _gameFactory = AllServices.Container.Single<IGameFactory>();
            _gameFactory.PlayerCreated += OnPlayerCreated;
            _layerMask =  1 << LayerMask.NameToLayer("PlayerCharacter");
        }

        private void Update()
        {
            if (CoolDownCheck())
            {
                _coolDownTime -= Time.deltaTime;
                return;
            }
            
            if(_attackIsActive && !_isAttacking)
               StartAttack();  
        }

        public void AttackDisable() => 
            _attackIsActive = false;

        public void AttackEnable() => 
            _attackIsActive = true;

        private void OnAttack()
        {
            if (Hit(out Collider2D hit))
            {
                hit.transform.GetComponent<PlayerHealth>().TakeDamage(Damage);
                Debug.Log(hit.name);
            }
        }

        private bool Hit(out Collider2D hit)
        {
            PhysicsDebug.DrawDebug(StartPoint(), Radius, 100);
            int hitsCount =  Physics2D.OverlapCircleNonAlloc(StartPoint(), Radius, _hits, _layerMask);

            hit = _hits.FirstOrDefault();
            return hitsCount > 0;
        }

        private Vector2 StartPoint()
        {
            return new Vector2(transform.position.x, transform.position.y + 2f) +
                   Vector2.left * _effectiveDistance;
        }

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

        private bool CoolDownCheck()
        {
            return _coolDownTime > 0;
        }

        private void OnPlayerCreated() => 
            _playerTransform = _gameFactory.Player.transform;
    }
}