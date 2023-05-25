using UnityEngine;

namespace SweetGame.CodeBase.Game.Player
{
    public class PlayerCharacter : MonoBehaviour//, ISavedProgress
    {
        // public void LoadProgress(PlayerProgress playerProgress)
        // {
        //     if (CurrentLevel() == playerProgress.WordData.PositionOnLevel.Level)
        //     {
        //         Vector3Data savedPosition = playerProgress.WordData.PositionOnLevel.Position;
        //         if (savedPosition != null)
        //             Warp(to: savedPosition);
        //     }
        // }
        //
        // private void Warp(Vector3Data to)
        // {
        //     transform.position = to.AsUnityVector();
        // }
        //
        // public void UpdateProgress(PlayerProgress playerProgress) =>
        //     playerProgress.WordData.PositionOnLevel =
        //         new PositionOnLevel(
        //             CurrentLevel(), transform.position.AsVectorData());
        //
        // private static string CurrentLevel()
        // {
        //     return SceneManager.GetActiveScene().name;
        // }
    }
}