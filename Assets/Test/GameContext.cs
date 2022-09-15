using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    [CreateAssetMenu(fileName = nameof(GameContext), menuName = "Test/" + nameof(GameContext))]
    public sealed class GameContext : ScriptableObject
    {

        #region Fields

        [SerializeField] public int Spirit = 0;

        #endregion

        #region Properties



        #endregion

    }
}