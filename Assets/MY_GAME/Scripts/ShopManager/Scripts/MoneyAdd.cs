using UnityEngine;

public class MoneyAdd : MonoBehaviour
{
    private SaveManager saveManager;

    private void Start()
    {
        saveManager = GameObject.FindWithTag("SaveManager").GetComponent<SaveManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SaveManager.instance.money += 100;
            SaveManager.instance.Save();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            SaveManager.instance.money -= 100;
            SaveManager.instance.Save();

        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            saveManager.DeleteSave();
            Debug.Log("Saves Delete");

        }
    }
}