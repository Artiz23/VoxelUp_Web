using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadLevel : MonoBehaviour
{
    public PauseMenu pauseMenu;  
    public GameObject loadingScreen;
    public float fakeLoadingTime = 5f;

    public void LoadLevelNumber(int sceneIndex)
    {
        StartCoroutine(LoadSceneAsync(sceneIndex));
        if (pauseMenu != null)
            pauseMenu.Resume();
    }

    private IEnumerator LoadSceneAsync(int sceneIndex)
    {
        loadingScreen.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
        asyncOperation.allowSceneActivation = false;

        float elapsed = 0f;

        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);

            if (elapsed < fakeLoadingTime)
            {
                elapsed += Time.deltaTime;
            }
            else
            {
                if (asyncOperation.progress >= 0.9f)
                {
                    asyncOperation.allowSceneActivation = true;
                }
            }

            yield return null;
        }

        loadingScreen.SetActive(false);
    }
}