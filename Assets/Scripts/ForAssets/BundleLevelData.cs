using UnityEngine;

namespace CardsGame
{
    [CreateAssetMenu(fileName = "NewBundleLevelData", menuName = "Bundle Level Data", order = 11)]
    public class BundleLevelData : ScriptableObject
    {
        [SerializeField]
        private LevelData[] _levelData;

        public LevelData[] LevelData => _levelData;
    }
}
