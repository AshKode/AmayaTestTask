using UnityEngine;

namespace CardsGame
{
    public class InputAnswer : MonoBehaviour
    {
        [SerializeField]
        private TaskSwitcher taskSwitcherScript;

        [SerializeField]
        private LevelSwitcher levelSwitcherScript;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                HandleTap();
            }
        }
        private void HandleTap(Vector3? touchPosition = null)
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 0;

            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);
            if (hit.collider != null)
            {
                string objectName = hit.collider.gameObject.name;
                Card card = hit.collider.gameObject.GetComponent<Card>();

                if (objectName == taskSwitcherScript.taskTarget)
                {
                    card.SymbolBounceEffect();
                    levelSwitcherScript.SwitchLevel(2);
                    taskSwitcherScript.taskTarget = null;
                }
                else
                {
                    card.EaseInBounceEffect();
                }
            }
        }
    }
}
