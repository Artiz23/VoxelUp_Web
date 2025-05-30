using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource voiceAudioSource;
    public AudioClip[] voiceClips;
    public AudioSource platformAudioSource;
    public AudioSource checkPointAudioSource;
    public AudioSource coinAudioSource;
    public AudioSource deathAudioSource;

    private int lastVoiceClipIndex = -1;

    private void Awake()
    {
        LoadAudioData(voiceAudioSource);
        LoadAudioData(platformAudioSource);
        LoadAudioData(checkPointAudioSource);
        LoadAudioData(coinAudioSource);
        LoadAudioData(deathAudioSource);
    }

    private void LoadAudioData(AudioSource audioSource)
    {
        if (audioSource.clip != null)
        {
            audioSource.clip.LoadAudioData();
        }
    }

    public void PlayPlatformSound(float volume = 1.0f)
    {
        platformAudioSource.PlayOneShot(platformAudioSource.clip, volume);
        PlayRandomVoiceSound(volume); // Воспроизводим случайный звук голоса
    }

    public void PlayCheckPointSound(float volume = 1.0f)
    {
        checkPointAudioSource.PlayOneShot(checkPointAudioSource.clip, volume);
    }

    public void PlayCoinSound(float volume = 1.0f)
    {
        coinAudioSource.PlayOneShot(coinAudioSource.clip, volume);
    }

    public void PlayDeathSound(float volume = 1.0f)
    {
        deathAudioSource.PlayOneShot(deathAudioSource.clip, volume);
    }

    private void PlayRandomVoiceSound(float volume = 1.0f)
    {
        if (voiceClips.Length > 0)
        {
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, voiceClips.Length);
            }
            while (randomIndex == lastVoiceClipIndex); // Гарантируем, что новый индекс не равен предыдущему

            lastVoiceClipIndex = randomIndex; // Сохраняем новый индекс
            voiceAudioSource.PlayOneShot(voiceClips[randomIndex], volume); // Проигрываем случайный звук
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScoreZone"))
        {
            PlayPlatformSound();
        }
        else if (other.CompareTag("CheckPoint"))
        {
            PlayCheckPointSound();
        }
    }
}
