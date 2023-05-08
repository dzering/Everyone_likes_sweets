using System;
using SweetGame.CodeBase.Logic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace SweetGame.CodeBase.Editor
{
    [CustomEditor(typeof(UniqueId))]
    public class EditorUniqueId : UnityEditor.Editor
    {
        private void OnEnable()
        {
            var uniqueId = (UniqueId) target;
            if(string.IsNullOrEmpty(uniqueId.Id))
                Generate(uniqueId);
            else
            {
                UniqueId[] uniqueIds = FindObjectsOfType<UniqueId>();
                foreach (var other in uniqueIds)
                {
                    if (uniqueId != other && other.Id == uniqueId.Id)
                    {
                        Generate(uniqueId);
                        return;
                    }
                }
            }
        }

        private void Generate(UniqueId uniqueId)
        {
            uniqueId.Id = $"{uniqueId.gameObject.scene.name}_{Guid.NewGuid().ToString()}";

            if (!Application.isPlaying)
            {
                EditorUtility.SetDirty(uniqueId);
                EditorSceneManager.MarkSceneDirty(uniqueId.gameObject.scene);                
            }

        }
    }
}