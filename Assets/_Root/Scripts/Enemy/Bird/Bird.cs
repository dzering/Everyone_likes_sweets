using UnityEngine;
using SweetGame.Abstractions;

namespace SweetGame.Enemy.Bird
{
    internal class Bird : BaseController, IEnemy
    {
        private float speedRelative;
        private float speed;
        private BirdView view;

        public Bird(float speed)
        {
            this.speed = speed;
            view = LoadView();
            speedRelative = view.SpeedRelative;
        }

        private BirdView LoadView()
        {
            GameObject pref = Resources.Load<GameObject>("Prefabs/Enemies/Bird");
            GameObject obj =  Object.Instantiate(pref);
            AddGameObject(obj);

            return obj.GetComponent<BirdView>();
        }

        public void Move()
        {
            view.transform.position += Vector3.left * speed * speedRelative * Time.deltaTime;
        }
    }
}
