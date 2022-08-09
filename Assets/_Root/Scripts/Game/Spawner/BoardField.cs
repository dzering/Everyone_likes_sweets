using SweetGame.Tools.Resource;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SweetGame.Game.Spawner
{
    internal sealed class BoardField
    {
        private readonly ResourcePath path = new ResourcePath("Prefabs/Utils/Board");
        private Transform[] points;
        private BoardFieldView view;

        public Transform[] Points
        {
            get { return points; }
            set { points = value; }
        }

        public BoardField(Transform[] points)
        {
            view = LoadBoard();
            view.Init(points);
        }

        public BoardFieldView LoadBoard()
        {
            GameObject pref = ResourceLoader.LoadGameObject(path);
            GameObject go = Object.Instantiate(pref);
            return go.GetComponent<BoardFieldView>();            
        }
    }
}
