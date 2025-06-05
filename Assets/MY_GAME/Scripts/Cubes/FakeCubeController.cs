using System.Collections;
using UnityEngine;

public class FakeCubeController : MonoBehaviour
{
    private GameObject player;

    [SerializeField] private GameObject[] cubeCreator;
    private void Start()
    {
        int randomIndex = Random.Range(0, cubeCreator.Length);
        if (cubeCreator != null)
        {
            cubeCreator[randomIndex].SetActive(true);
        }

        player = GameObject.FindWithTag("Player");
        StartCoroutine(CheckFakeCube());
    }

    public IEnumerator CheckFakeCube()
    {
        yield return new WaitForSeconds(1.0f);
        if (player.transform.position.y - transform.position.y > 6.0f)
        {
            Destroy(gameObject);
        }
        else if (player.transform.position.y - transform.position.y > 1.0f)
        {
            FallFakeCube();
        }
        else
        {
            StartCoroutine(CheckFakeCube());
        }

    }

    private void FallFakeCube()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        Destroy(gameObject, 2f);
    }
}
