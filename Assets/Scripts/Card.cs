using DG.Tweening;
using UnityEngine;

namespace CardsGame
{
    public class Card : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer SpriteOutline;

        [SerializeField]
        private SpriteRenderer SpriteSymbol;

        [SerializeField]
        private SpriteRenderer SpriteQuad;

        [SerializeField]
        private ParticleSystem particle;

        [SerializeField]
        private Vector3 OriginalScale;

        private Sequence _scaleSequence;

        private float currentX;

        private void OnEnable()
        {
            currentX = transform.position.x;
        }
        public void BounceEffect(float delay)
        {
            transform.localScale = Vector3.zero;

            _scaleSequence = DOTween.Sequence();

            _scaleSequence.Append(transform.DOScale(OriginalScale * 1.1f, 0.2f));
            _scaleSequence.Append(transform.DOScale(OriginalScale * 0.9f, 0.1f));
            _scaleSequence.Append(transform.DOScale(OriginalScale, 0.1f));

            _scaleSequence.SetDelay(delay);
        }
        public void SymbolBounceEffect()
        {
            particle.Play();

            SpriteOutline.sortingOrder = 23;
            SpriteSymbol.sortingOrder = 22;
            SpriteQuad.sortingOrder = 21;

            Transform symbol = SpriteSymbol.transform;

            _scaleSequence = DOTween.Sequence();

            _scaleSequence.Append(symbol.DOScale(1.2f, 0.1f));
            _scaleSequence.Append(symbol.DOScale(0.8f, 0.15f));
            _scaleSequence.Append(symbol.DOScale(1, 0.15f));
        }
        public void EaseInBounceEffect()
        {
            SpriteOutline.sortingOrder = 23;
            SpriteSymbol.sortingOrder = 22;
            SpriteQuad.sortingOrder = 21;

            Transform symbol = SpriteSymbol.transform;

            _scaleSequence = DOTween.Sequence();

            _scaleSequence.Append(symbol.DOMoveX(currentX + 0.15f, 0.1f));
            _scaleSequence.Append(symbol.DOMoveX(currentX - 0.1f, 0.1f));
            _scaleSequence.Append(symbol.DOMoveX(currentX, 0.1f));

            _scaleSequence.OnComplete(() => {
                SpriteOutline.sortingOrder = 3;
                SpriteSymbol.sortingOrder = 2;
                SpriteQuad.sortingOrder = 1;
            });
        }
        public void SetRotate_Z(float zAngle)
        {
            SpriteSymbol.transform.rotation = Quaternion.Euler(0, 0, zAngle);
        }
        public void SetColor(Color color)
        {
            SpriteQuad.color = color;
        }
        public void SetSprite(Sprite sprite)
        {
            SpriteSymbol.sprite = sprite;
        }
    }
}