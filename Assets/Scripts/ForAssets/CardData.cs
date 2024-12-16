using System;
using UnityEngine;

namespace CardsGame
{
    [Serializable]
    public class CardData
    {
        [SerializeField]
        private string _name;

        [SerializeField]
        private Sprite _sprite;

        [SerializeField]
        private Color _color;

        [SerializeField]
        private float _zAngle;

        public string name => _name;

        public Sprite sprite => _sprite;

        public Color color => _color;

        public float zAngle => _zAngle;
    }
}
