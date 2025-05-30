using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trap : MonoBehaviour
{
    private PlayerDeath playerDeath;
    private CubeJump cubeJump;

    void Start()
    {
        playerDeath = GetComponent<PlayerDeath>();
        cubeJump = GetComponent<CubeJump>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            playerDeath.Die();
            StartCoroutine(DelayedRestartScene());
            cubeJump.isMove = false;
        }
    }
    
    public void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private IEnumerator DelayedRestartScene()
    {
        yield return new WaitForSeconds(0.7f);
        RestartScene();
    }
}
