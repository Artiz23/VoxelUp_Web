using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance { get; private set; }

    public int currentCar;
    public int money;
    public int highscore;
    public bool[] carsUnlocked = new bool[6] { true, false, false, false, false, false };

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;

        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData_Storage data = (PlayerData_Storage)bf.Deserialize(file);

            money = data.money;
            currentCar = data.currentCar;
            carsUnlocked = data.carsUnlocked;
            highscore = data.highscore;

            if (data.carsUnlocked == null)
                carsUnlocked = new bool[6] { true, false, false, false, false, false };

            file.Close();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData_Storage data = new PlayerData_Storage();

        data.money = money;
        data.currentCar = currentCar;
        data.carsUnlocked = carsUnlocked;
        data.highscore = highscore;

        bf.Serialize(file, data);
        file.Close();
    }

    public void DeleteSave()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            File.Delete(Application.persistentDataPath + "/playerInfo.dat");
            Debug.Log("Файл сохранения удален.");
        }
        else
        {
            Debug.Log("Нет файла сохранения для удаления.");
        }
    }
}

[Serializable]
class PlayerData_Storage
{
    public int currentCar;
    public int money;
    public int highscore;
    public bool[] carsUnlocked;
}
