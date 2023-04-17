using UnityEngine;

namespace UpdateManager.Example_Scene.Scripts
{
    public class ExampleEventUpdate : MonoBehaviour {
        private int i;

        private void OnEnable() {
            UpdateManager.Scripts.UpdateManager.SubscribeToUpdate(EventUpdate);
        }

        private void OnDisable() {
            UpdateManager.Scripts.UpdateManager.UnsubscribeFromUpdate(EventUpdate);
        }

        private void EventUpdate() {
            i++;
        }
    }
}