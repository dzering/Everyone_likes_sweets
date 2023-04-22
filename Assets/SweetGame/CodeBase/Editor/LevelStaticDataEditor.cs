using System.Linq;
using SweetGame.CodeBase.Game.Spawner;
using SweetGame.CodeBase.Logic;
using SweetGame.CodeBase.StaticData;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CustomEditor(typeof(LevelStaticData))]
public class LevelStaticDataEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        LevelStaticData levelStateData = (LevelStaticData)target;

        if (GUILayout.Button("Collect"))
        {
            levelStateData.EnemySpawnersData = FindObjectsOfType<SpawnMarker>()
                .Select(x => new EnemySpawnerData(x.GetComponent<UniqueId>().Id, x.EnemyTypeId, x.transform.position))
                .ToList();

            levelStateData.LevelKey = SceneManager.GetActiveScene().name;
        }
        
        EditorUtility.SetDirty(target);
    }
}