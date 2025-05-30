using System.Collections;
using UnityEngine;

public class mine : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(DestroyMine());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator DestroyMine()
    {
        yield return new WaitForSeconds(1.0f);

        if (player.transform.position.y - transform.position.y > 6)
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(DestroyMine());
        }
    }
}
