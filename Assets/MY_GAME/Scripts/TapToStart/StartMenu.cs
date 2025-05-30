using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject startMenuUI;
    public GameObject shopButton;
    public GameObject pauseButton;

    private void Start()
    {
        startMenuUI.SetActive(true);
    }

    public void StartGame()
    {
        startMenuUI.SetActive(false);
        Invoke("ActivatePauseButton", 0.3f);
    }
    void ActivatePauseButton()
    {
        shopButton.SetActive(false);
        pauseButton.SetActive(true);
    }
}