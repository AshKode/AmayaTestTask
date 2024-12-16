using UnityEngine;

namespace CardsGame
{
    [CreateAssetMenu(fileName = "NewBundleCardData", menuName = "Bundle Card Data", order = 10)]
    public class BundleCardData : ScriptableObject
    {
        [SerializeField]
        private CardData[] _cardData;

        public CardData[] CardData => _cardData;
    }
}
