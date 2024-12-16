using UnityEngine;

namespace CardsGame
{
    public class Grid : MonoBehaviour
    {
        [SerializeField]
        private float _cellSize = 1f;

        [SerializeField]
        private GameObject _cellPrefab;

        public Transform[,] grid;

        public BundleCardData symbols;

        public bool onlyStart = true;

        public void GenerateGrid(int width, int height)
        {
            if (width * height > symbols.CardData.Length)
            {
                Debug.Log("Кол-во ячеек больше, чем объектов в BundleCardData");
                return;
            }

            transform.position = -new Vector3((width * _cellSize - _cellSize) / 2, (height * _cellSize - _cellSize) / 2); //выглядит как хардкод наверное, но здесь формула. Это центрирование сетки

            //создаю и перемешиваю массив для рандомизации без повторений
            int[] numbersForRandomize = new int[symbols.CardData.Length];
            for (int i = 0; i < numbersForRandomize.Length; i++)
            {
                numbersForRandomize[i] = i;
            }

            ShuffleArray(numbersForRandomize);
            int _iNumbers = 0;

            if (grid != null)
            {
                ClearGrid();
            }

            grid = new Transform[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++, _iNumbers++)
                {
                    Vector3 cellPosition = transform.position + new Vector3(x * _cellSize, y * _cellSize, 0f);
                    GameObject cellInstance = Instantiate(_cellPrefab, cellPosition, Quaternion.identity, transform);

                    int random = numbersForRandomize[_iNumbers];
                    Card cellCard = cellInstance.GetComponent<Card>();
                    cellCard.SetColor(symbols.CardData[random].color);
                    cellCard.SetSprite(symbols.CardData[random].sprite);
                    cellCard.SetRotate_Z(symbols.CardData[random].zAngle);
                    cellCard.gameObject.name = symbols.CardData[random].name;

                    if (onlyStart) cellCard.BounceEffect(_iNumbers * 0.1f);

                    grid[x, y] = cellInstance.transform;
                }
            }
            onlyStart = false;
        }

        public void ClearGrid()
        {
            foreach (Transform cell in grid)
            {
                if (cell != null)
                    Destroy(cell.gameObject);
            }
            grid = null;
        }

        void ShuffleArray(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int randomIndex = Random.Range(i, array.Length);
                int temp = array[i];
                array[i] = array[randomIndex];
                array[randomIndex] = temp;
            }
        }
    }
}