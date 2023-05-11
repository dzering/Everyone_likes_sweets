using System.Linq;
using SweetGame.CodeBase.Animators;
using SweetGame.CodeBase.Game.Player;
using SweetGame.CodeBase.Utils;
using UnityEngine;

namespace SweetGame.CodeBase.Game.Enemy
{
    [RequireComponent(typeof(AnimatorBase))]
    public class Attack : MonoBehaviour
    {
        private const string LAYER_NAME = "PlayerCharacter";
      
        public float EffectiveDistance;
        public AnimatorBase AnimatorBase;
        public float CoolDownTime;
        public float Damage;
        
        private Transform _playerTransform;

        private float _coolDownTime;
        private bool _isAttacking;
        private int _layerMask;
        private readonly Collider2D[] _hits = new Collider2D[1];
        private float Attack_Radius = 1f;
        private bool _attackIsActive;


        private void Awake()
        {
            _layerMask =  1 << LayerMask.NameToLayer(LAYER_NAME);
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
            PhysicsDebug.DrawDebug(StartPoint(), Attack_Radius, 100);
            int hitsCount =  Physics2D.OverlapCircleNonAlloc(StartPoint(), Attack_Radius, _hits, _layerMask);

            hit = _hits.FirstOrDefault();
            return hitsCount > 0;
        }

        private Vector2 StartPoint()
        {
            return new Vector2(transform.position.x, transform.position.y + 2f) +
                   Vector2.left * EffectiveDistance;
        }

        private void OnAttackEnded()
        {
            _coolDownTime = CoolDownTime;
            _isAttacking = false;
        }

        private void StartAttack()
        {
            _isAttacking = true;
            AnimatorBase.PlayAttack();
        }

        private bool CoolDownCheck() => 
            _coolDownTime > 0;

        public void Construct(Transform playerTransform) => 
            _playerTransform = playerTransform;
    }
}