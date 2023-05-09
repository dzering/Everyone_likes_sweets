using SweetGame.CodeBase.Game.Enemy;
using UnityEngine;

namespace SweetGame.CodeBase.Game.Destructor
{
    public class Destructor : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _observer;
        public string ID;

        private void Start()
        {
            _observer.TriggerEnter += OnTrigger;
        }

        private void OnTrigger(Collider2D obj) => 
            Destroy(obj.transform.parent.gameObject);
    }
    
}
