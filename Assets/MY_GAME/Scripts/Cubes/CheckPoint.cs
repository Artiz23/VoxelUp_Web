using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public ParticleSystem particlePoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            particlePoint.Play();
        }
    }
}
