using System.Collections;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FallAndDestroyCoroutine());
        }
    }

    private IEnumerator FallAndDestroyCoroutine()
    {
        yield return new WaitForSeconds(0f);
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;

        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}

