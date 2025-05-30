using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour
{
    private ParticleSystem ps_Fire;
    public ParticleSystem ps_tourchFire;
    private Collider boxCollider;
    private AudioSource audioSource;
    private bool isFire = true;

    void Start()
    {
        ps_Fire = GetComponent<ParticleSystem>();
        boxCollider = GetComponent<Collider>();
        audioSource = GetComponent<AudioSource>();

        ps_Fire.Stop();
        boxCollider.enabled = false;
        audioSource.Stop();

        StartCoroutine(FireControl());
    }

    private IEnumerator FireControl()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            ps_tourchFire.Play();

            if (isFire)
            {
                yield return new WaitForSeconds(1f);
                ps_tourchFire.Stop();
                ps_Fire.Play();
                boxCollider.enabled = true;
                audioSource.Play();
                yield return new WaitForSeconds(1f);
                ps_Fire.Stop();
                boxCollider.enabled = false;
                audioSource.Stop();
            }
            else
            {
                ps_Fire.Stop();
                boxCollider.enabled = false;
                audioSource.Stop();
                yield return new WaitForSeconds(2.0f);
            }

            isFire = !isFire;
        }
    }
}
