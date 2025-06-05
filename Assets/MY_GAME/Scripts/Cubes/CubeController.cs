using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour
{
    public GameObject coin;
    private Vector3 offset = new Vector3(0, 1.3f, 2);
    private Vector3 offsetThorns = new Vector3(0, 0.475f, 2);
    public Animation anim;
    public ParticleSystem particleSystems;
    public float countFall = 5.0f;
    public GameObject[] thornsTrap;
    public GameObject fireObject;
    public GameObject chinaCube;

    public AudioSource audioSource;

    private int fireScore = 95;
    private int mineScore = 90;
    private int coinScore = 95;


    private void Start()
    {
        if (ScoreManager.score > 50)
        {
            coinScore = 85;
            mineScore = 85;
            fireScore = 90;
        }else if(ScoreManager.score > 300)
        {
            coinScore = 75;
            mineScore = 80;
            fireScore = 85;
        }else if(ScoreManager.score > 800)
        {
            coinScore = 65;
            mineScore = 75;
            fireScore = 80;
        }


        int valueRandom = Random.Range(0, 100);
        if (valueRandom > coinScore && coin != null)
        {
            Instantiate(coin, transform.position + offset, coin.transform.rotation);
        }



        if (thornsTrap != null && thornsTrap.Length > 0 && thornsTrap[0] != null && valueRandom > mineScore)
        {
            Instantiate(thornsTrap[0], transform.position + offsetThorns, thornsTrap[0].transform.rotation);
        }

        else if (valueRandom > fireScore && fireObject != null)
        {

            fireObject.SetActive(true);
        }
    }

    //China Platform
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (anim != null)
            {
                anim.Play();
            }

            StartCoroutine(FallCoroutineHolding());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            StartCoroutine(FallAndDestroyCoroutine());
        }
    }

    private IEnumerator FallCoroutineHolding()
    {

        yield return new WaitForSeconds(countFall);
        if (particleSystems != null)
        {
            particleSystems.Play();
        }



        if (audioSource != null)
        {
            audioSource.Play();
        }

        if (chinaCube != null)
        {
            Destroy(chinaCube);
        }
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;

        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }

    private IEnumerator FallAndDestroyCoroutine()
    {
        yield return new WaitForSeconds(0f);
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;

        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}