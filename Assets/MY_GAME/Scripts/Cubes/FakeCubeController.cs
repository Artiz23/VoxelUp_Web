using System.Collections;
using UnityEngine;

public class FakeCubeController : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(CheckFakeCube());
    }

    public IEnumerator CheckFakeCube()
    {
        yield return new WaitForSeconds(1.0f);
        if (player.transform.position.y - transform.position.y > 6)
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(CheckFakeCube());
        }

    }
}
