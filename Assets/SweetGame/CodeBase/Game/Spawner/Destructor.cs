using SweetGame.CodeBase.Game.Enemy;
using SweetGame.CodeBase.Infrastructure.AssetManagement;
using UnityEngine;
using UnityEngine.Serialization;

namespace SweetGame.CodeBase.Game.Destructor
{
    public class Destructor : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _observer;

        private void Start()
        {
            _observer.TriggerEnter += OnTrigger;
        }

        private void OnTrigger(Collider2D obj) => 
            Destroy(obj.transform.parent.gameObject);
    }
    
}
