using UnityEngine;

namespace CardsGame
{
    public class LevelSwitcher : MonoBehaviour
    {
        [SerializeField]
        private Grid gridScript;

        [SerializeField]
        private TaskSwitcher taskSwitcherScript;

        [SerializeField]
        private RestartButton restartButtonScript;

        [SerializeField]
        private BundleLevelData levelsBundle;

        private int _currentLevel;

        private float _timerSwitchLevel;

        private void Start()
        {
            SwitchLevel(0.5f);
        }

        public void SwitchLevel(float delay)
        {
            Invoke("SwitchLevelDelay", delay);
        }
        private void SwitchLevelDelay()
        {
            if (_currentLevel == levelsBundle.LevelData.Length)
            {
                restartButtonScript.GetRestartScreen(1.5f);
                _currentLevel = 0;
                return;
            }

            gridScript.symbols = levelsBundle.LevelData[_currentLevel].cardGroup;

            int width = levelsBundle.LevelData[_currentLevel].gridSize.x;
            int height = levelsBundle.LevelData[_currentLevel].gridSize.y;

            gridScript.GenerateGrid(width, height);
            taskSwitcherScript.GenerateTask();

            _currentLevel++;
        }
    }
}
