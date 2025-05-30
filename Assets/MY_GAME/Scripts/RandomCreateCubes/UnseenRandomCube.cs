using UnityEngine;

public class UnseenRandomCube : MonoBehaviour
{
    public GameObject cubePrefab;
    private Vector3Int lastCubePosition;

    void Start()
    {
        lastCubePosition = new Vector3Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateRandomCube();
        }
    }

    public void CreateRandomCube()
    {
        // Генерация случайного смещения -2 или 2 для x
        int offsetX = (Random.Range(0, 2) == 0) ? -2 : 2;
        int offsetY = 1;
        int offsetZ = 2;  

        // Генерация случайного направления (вправо или вперед)
        int randomDirection = Random.Range(0, 2);

        // Создание новой позиции для куба относительно последнего куба
        Vector3Int newPosition = lastCubePosition + new Vector3Int((randomDirection == 0) ? offsetX : 0, offsetY, (randomDirection == 1) ? offsetZ : 0);


        GameObject newCube = Instantiate(cubePrefab, newPosition, Quaternion.identity);

        // Обновление переменной с последней позицией
        lastCubePosition = new Vector3Int(Mathf.RoundToInt(newCube.transform.position.x), Mathf.RoundToInt(newCube.transform.position.y), Mathf.RoundToInt(newCube.transform.position.z));
    }
}