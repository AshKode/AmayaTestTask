using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

namespace CardsGame
{
    public class RestartButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private LevelSwitcher levelSwitcherScript;

        [SerializeField]
        private InputAnswer inputAnswerScript;

        [SerializeField]
        private Grid gridScript;

        [SerializeField]
        private Image fadeQoadImage;

        private Sequence _scaleSequence;

        private Sequence _fadeSequence;

        public void GetRestartScreen(float delay)
        {
            _scaleSequence = DOTween.Sequence();

            _scaleSequence.Append(transform.DOScale(1.2f, 0.2f));
            _scaleSequence.Append(transform.DOScale(0.8f, 0.1f));
            _scaleSequence.Append(transform.DOScale(1, 0.1f));

            _scaleSequence.SetDelay(delay);

            fadeQoadImage.DOFade(0.85f, 0.4f).SetDelay(delay);

            inputAnswerScript.enabled = false;
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            gridScript.onlyStart = true;

            levelSwitcherScript.SwitchLevel(1.2f);

            _scaleSequence = DOTween.Sequence();

            _scaleSequence.Append(transform.DOScale(0.8f, 0.2f));
            _scaleSequence.Append(transform.DOScale(1.2f, 0.1f));
            _scaleSequence.Append(transform.DOScale(0, 0.1f));

            _fadeSequence = DOTween.Sequence();

            _fadeSequence.Append(fadeQoadImage.DOFade(1, 0.2f));
            _fadeSequence.Append(fadeQoadImage.DOFade(0, 0.5f).SetDelay(1f));
            _fadeSequence.OnComplete(() =>
            {
                inputAnswerScript.enabled = true;
            });
        }
    }
}
