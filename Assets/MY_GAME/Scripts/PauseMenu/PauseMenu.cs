using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject restartUI;
    public GameObject playUI;
    public GameObject shopUI;
    public GameObject pauseMenuUI;
    public GameObject pauseButton;
    public GameObject skinsChangeButton;
    public GameObject caseShop;
    public GameObject skinsCamera;
    private bool isPaused = false;
    private CubeJump cubeJump;

    private void Start()
    {
        GameObject playerController = GameObject.FindWithTag("PlayerController");
        if (playerController != null)
        {
            cubeJump = playerController.GetComponentInChildren<CubeJump>();
        }
    }

    public void Resume()
    {
        CubeJump.isShop = true;
        pauseMenuUI.SetActive(false);
        pauseButton.SetActive(true);
        skinsChangeButton.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        StartCoroutine(PauseOff());
        skinsCamera.SetActive(false);
    }

    private IEnumerator PauseOff()
    {
        yield return new WaitForSeconds(0.2f);
        cubeJump.isMove = true;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
        cubeJump.isMove = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SkinChange()
    {
        isPaused = true;
        cubeJump.isMove = false;
        skinsChangeButton.SetActive(false);
        pauseMenuUI.SetActive(true);
        CubeJump.isShop = false;
        skinsCamera.SetActive(true);
    }

    public void CaseShopOpen()
    {
        caseShop.SetActive(true);
    }

    public void CaseShopClose()
    {
        caseShop.SetActive(false);
    }


    public void ActivePauseMenu()
    {
        pauseButton.SetActive(true);
        restartUI.SetActive(true);
        pauseMenuUI.SetActive(true);
        playUI.SetActive(false);
        pauseButton.SetActive(false);
    }


    public void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
