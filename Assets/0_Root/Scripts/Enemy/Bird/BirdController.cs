using UnityEngine;
using SweetGame.Abstractions.Base;

namespace SweetGame.Enemy
{
    internal class BirdController : EnemyBase
    {
        private float speedRelative;
        private float speed;
        private BirdView view;

        public BirdController(float speed)
        {
            this.speed = speed;
            view = LoadView();
            speedRelative = view.SpeedRelative;
        }

        private BirdView LoadView()
        {
            GameObject pref = Resources.Load<GameObject>("Prefabs/Enemies/Bird");
            GameObject obj =  Object.Instantiate(pref);

            return obj.GetComponent<BirdView>();
        }

        public override void Move()
        {
            view.transform.position += Vector3.left * speed * speedRelative * Time.deltaTime;
        }
    }
}
