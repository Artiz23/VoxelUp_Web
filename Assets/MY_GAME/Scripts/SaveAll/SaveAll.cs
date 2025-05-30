using UnityEngine;

public class SaveAll : MonoBehaviour
{
    private SaveManager saveManager;
    void Start()
    {
        saveManager = GameObject.FindWithTag("SaveManager").GetComponent<SaveManager>();
    }
}
