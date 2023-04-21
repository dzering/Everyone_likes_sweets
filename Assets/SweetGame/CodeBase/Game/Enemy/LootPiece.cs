using System;
using System.Collections;
using SweetGame.CodeBase.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace SweetGame.CodeBase.Game.Enemy
{
    public class LootPiece : MonoBehaviour
    {
        public GameObject Model;
        public GameObject PickupFXPrefab;
        public TextMeshPro LootText;
        public GameObject PickupPopup;

        private Loot _loot;
        private bool _isPicked;
        private WorldData _worldData;

        public void Construct(WorldData worldData)
        {
            _worldData = worldData;
        }

        public void Initialize(Loot loot) =>
            _loot = loot;

        private void OnTriggerEnter2D(Collider2D col) => PickUp();

        private void PickUp()
        {
            if (_isPicked)
                return;

            _isPicked = true;
            UpdateWorldDate();
            HideModel();
            ShowText();
            PlayPickupFX();

            StartCoroutine(DestroyTimer());
        }

        private void UpdateWorldDate() =>
            _worldData.LootData.Collect(_loot);

        private void HideModel() =>
            Model.SetActive(false);

        private void ShowText()
        {
            LootText.text = $"{_loot.Value}";
            PickupPopup.SetActive(true);
        }

        private void PlayPickupFX()
        {
            if (PickupFXPrefab != null) 
                Instantiate(PickupFXPrefab, transform.position, Quaternion.identity);
        }

        private IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
        }
    }
}