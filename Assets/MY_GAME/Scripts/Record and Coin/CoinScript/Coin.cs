using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject coinSkin;
    public GameObject coin;
    private GameObject player;
    
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(DestroyCoin());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(coinSkin);
        }
    }

    private IEnumerator DestroyCoin()
    {
        yield return new WaitForSeconds(1.0f);

        if (player.transform.position.y - transform.position.y > 6)
        {
            Destroy(coin);
        }
        else
        {
            StartCoroutine(DestroyCoin());
        }
    }
}
