using System.Collections.Generic;
using SweetGame.CodeBase.Data.Spawner;
using UnityEditor;
using UnityEngine;

namespace SweetGame.Editor
{
    [CustomEditor(typeof(SpawnPointsConfig))]
    public class SpawnPointsEditor : UnityEditor.Editor
    {
        private SpawnPointsConfig config; 
        public override void OnInspectorGUI()
        {

            base.OnInspectorGUI();
            config = (SpawnPointsConfig)target;

            if (GUILayout.Button("Edit"))
            {
                Debug.Log("Edit button was pressed");
                Clear(Conteiner.spawnPoints);
                CreatePoints(config.SpawnPoints);
            }

            if (GUILayout.Button("Save"))
            {
                Debug.Log("Save button was pressed");
                SavePoints(Conteiner.spawnPoints);
            }
        }

        private void Clear(IEnumerable<GameObject> collection)
        {
            foreach (var item in collection)
            {
                GameObject.DestroyImmediate(item);
            }
            Conteiner.spawnPoints.Clear();
        }

        private void CreatePoints(IEnumerable<SpawnPoint> collection)
        {
            foreach (var item in collection)
            {
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                go.transform.position = item.position;
                Conteiner.spawnPoints.Add(go);
            }
        }

        private void SavePoints(List<GameObject> collection)
        {
            for (int i = 0; i < config.SpawnPoints.Length; i++)
            {
                config.SpawnPoints[i].position = collection[i].transform.position;
            }

            Clear(collection);
        }
    }
}
