using UnityEngine;

public class RandomCube : MonoBehaviour
{
    public GameObject[] cubePrefab;
    private Vector3Int lastCubePosition;
    public bool canCreateLeft = true;
    public bool canCreateRight = true;
    private GameObject newCube;
    public int countFirstPrefab = 4;

    private int countCube = 2;
    public int canCreateCount = 4;

    private bool canCreateFakeL = false;
    private bool canCreateFakeR = false;

    public int countCreateFake = 0;

    
    public int onlyForward = 0;

    public int createdCubes = 0;


    private int chinaScore = 90;
    private int moveScore = 2;

    void Start()
    {
        lastCubePosition = new Vector3Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));

        for (int i = 0; i < 10; i++)
        {
            CreateRandomCube();
        }
    }

    // int GetWeightedRandomY()
    // {
    //     {
    //         int random = Random.Range(0, 100);
    //         return random < 70 ? 1 : 0;
    //     }    
    // }
    
    public void CreateRandomCube()
    {
        if (ScoreManager.score > 50)
        {
            chinaScore = 85;
            moveScore = 5;
        }
        else if (ScoreManager.score > 300)
        {
            chinaScore = 70;
            moveScore = 10;
        }
        else if (ScoreManager.score > 800)
        {
            chinaScore = 65;
            moveScore = 15;
        }


        int offsetX = 0;
        int offsetY = 1;
        int offsetZ = 2;


        if (canCreateRight && !canCreateLeft)
        {
            offsetX = 2;
        }
        else if (canCreateLeft && !canCreateRight)
        {
            offsetX = -2;
        }
        else
        {
            offsetX = (Random.Range(0, 2) == 0) ? -2 : 2;

            if (offsetX == 2)
            {
                canCreateFakeR = true;
                canCreateFakeL = false;

                canCreateLeft = false;
                canCreateRight = true;

            }
            else if (offsetX == -2)
            {
                canCreateFakeR = false;
                canCreateFakeL = true;

                canCreateLeft = true;
                canCreateRight = false;
            }
        }

        // Генерация случайного направления (X или Z)
        int randomDirection;
        int randomValue = Random.Range(0, 100); // Генерация случайного числа от 0 до 100

        if (randomValue < 50 && countCube != 0 && countCreateFake > 0 && onlyForward < 1)
        {
            // 40% вероятность выпадения значения 0  X
            randomDirection = 0;

            countCube -= 1;
        }
        else
        {
            // 60% вероятность выпадения значения 2  Z
            randomDirection = 2;

            countCube = canCreateCount;
            onlyForward -= 1;
        }


        // int randomDirection = Random.Range(0, 2);
        if (randomDirection == 2)
        {
            canCreateLeft = true;
            canCreateRight = true;

            canCreateFakeL = false;
            canCreateFakeR = false;
        }

        
        // int randomY = GetWeightedRandomY();
        // Создание новой позиции для куба относительно последнего куба
        Vector3Int newPosition = lastCubePosition + new Vector3Int((randomDirection == 0) ? offsetX : 0, 1, (randomDirection == 2) ? offsetZ : 0);

        int randomChance = Random.Range(0, 100);


        if (createdCubes == 49)
        {
            //Check Point
            newCube = Instantiate(cubePrefab[6], newPosition, Quaternion.identity);
            countFirstPrefab += 1;
            countCreateFake += 1;

            createdCubes = 0;
        }
        else
        // Если случайное число меньше 1, создаем второй префаб с вероятностью 10%
        if (randomChance < moveScore && countFirstPrefab >= 4)
        {
            newCube = Instantiate(cubePrefab[1], newPosition, Quaternion.identity);
            countFirstPrefab = 0;

            createdCubes += 1;
        }
        else if (randomChance > 90 && canCreateFakeL == true && countCreateFake >= 5)
        {
            // fake cube L
            newCube = Instantiate(cubePrefab[2], newPosition, Quaternion.identity);
            countFirstPrefab += 1;
            canCreateFakeL = false;
            countCreateFake = 0;

            createdCubes += 1;
        }
        else if (randomChance > 85 && canCreateFakeR == true && countCreateFake >= 5)
        {
            // fake cube R
            newCube = Instantiate(cubePrefab[3], newPosition, Quaternion.identity);
            countFirstPrefab += 1;
            canCreateFakeR = false;
            countCreateFake = 0;

            createdCubes += 1;
        }
        else if (randomChance > 60 && canCreateFakeR == true && countCreateFake >= 5)
        {
            // fake cube R2
            newCube = Instantiate(cubePrefab[4], newPosition, Quaternion.identity);
            countFirstPrefab += 1;
            canCreateFakeR = false;
            countCreateFake = 0;

            onlyForward = 2;

            createdCubes += 1;
        }
        else if (randomChance > 70 && canCreateFakeL == true && countCreateFake >= 5)
        {
            // fake cube L2
            newCube = Instantiate(cubePrefab[5], newPosition, Quaternion.identity);
            countFirstPrefab += 1;
            canCreateFakeR = false;
            countCreateFake = 0;

            onlyForward = 2;

            createdCubes += 1;
        }
        else if (randomChance > 50 && canCreateFakeL == true && countCreateFake >= 5)
        {
            // fake cube L3
            newCube = Instantiate(cubePrefab[8], newPosition, Quaternion.identity);
            countFirstPrefab += 1;
            canCreateFakeR = false;
            countCreateFake = 0;

            onlyForward = 2;

            createdCubes += 1;
        }
        else if (randomChance > 50 && canCreateFakeR == true && countCreateFake >= 5)
        {
            // fake cube R3
            newCube = Instantiate(cubePrefab[9], newPosition, Quaternion.identity);
            countFirstPrefab += 1;
            canCreateFakeR = false;
            countCreateFake = 0;

            onlyForward = 2;

            createdCubes += 1;
        }
        else if (randomChance > chinaScore)
        {
            // china cube
            newCube = Instantiate(cubePrefab[7], newPosition, Quaternion.identity);
            countFirstPrefab += 1;
            countCreateFake += 1;

            createdCubes += 1;
        }
        else
        {
            // default cube
            newCube = Instantiate(cubePrefab[0], newPosition, Quaternion.identity);
            countFirstPrefab += 1;
            countCreateFake += 1;

            createdCubes += 1;
        }

        ///////////////////////////////////////////////////////////////////////
        // Обновление переменной с последней позицией
        lastCubePosition = new Vector3Int(Mathf.RoundToInt(newCube.transform.position.x), Mathf.RoundToInt(newCube.transform.position.y), Mathf.RoundToInt(newCube.transform.position.z));
    }
}