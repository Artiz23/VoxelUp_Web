using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    public void PlaySimpleBtn(int index)
    {
        audioSource.PlayOneShot(audioClips[index]);
    }
}
