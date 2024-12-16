using System;
using UnityEngine;

namespace CardsGame
{
    [Serializable]
    public class LevelData
    {
        [SerializeField]
        private BundleCardData _cardGroup;

        [SerializeField]
        private Vector2Int _gridSize;

        public BundleCardData cardGroup => _cardGroup;

        public Vector2Int gridSize => _gridSize;
    }
}
