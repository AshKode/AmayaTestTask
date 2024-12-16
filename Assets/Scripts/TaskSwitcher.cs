using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace CardsGame
{
    public class TaskSwitcher : MonoBehaviour
    {
        [SerializeField]
        private Text taskText;

        [SerializeField]
        private Grid gridScript;

        public string taskTarget;

        private void Start()
        {
            taskText.DOFade(1, 0.5f).SetDelay(0.5f);
        }
        public void GenerateTask()
        {
            int width = gridScript.grid.GetLength(0);
            int height = gridScript.grid.GetLength(1);
            int randomX = Random.Range(0, width);
            int randomY = Random.Range(0, height);

            taskTarget = gridScript.grid[randomX, randomY].gameObject.name;

            taskText.text = "Find " + taskTarget;
        }
    }
}
