using SweetGame.CodeBase.Infrastructure.AssetManagement;
using SweetGame.CodeBase.Infrastructure.Services;
using SweetGame.CodeBase.Infrastructure.Services.Input;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SweetGame.CodeBase.Game.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        private IInputService _input;
        private float _coolDownTime;
        public float CoolDownTime = 2f;

        private void Awake() => 
            _input = AllServices.Container.Single<IInputService>();

        private void Update()
        {
            if (CoolDownCheck())
            {
                _coolDownTime -= Time.deltaTime;
                return;
            }
            
            Attack();
        }

        private bool CoolDownCheck() => 
            _coolDownTime > 0;

        private void Attack()
        {
            if (_input.AttackButtonUp)
            {
                _coolDownTime = CoolDownTime;
                Addressables.InstantiateAsync(
                    AssetAddress.BOMB, transform.position, quaternion.identity);
            }
        }
    }
}