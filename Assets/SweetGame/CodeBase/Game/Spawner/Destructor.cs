using SweetGame.CodeBase.Game.Enemy;
using UnityEngine;

namespace SweetGame.CodeBase.Game.Spawner
{
    public class Destructor : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _observer;
        public string ID;

        private void Start()
        {
            _observer.TriggerEnter += OnTrigger;
        }

        private void OnTrigger(Collider2D obj)
        {
            IDestructible destructible = obj.GetComponentInParent<IDestructible>();
            destructible?.DestructObject();
        }
    }
    
}
