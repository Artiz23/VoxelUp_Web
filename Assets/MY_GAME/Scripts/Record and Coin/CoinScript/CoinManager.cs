using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public SoundManager soundManager;
    private const string CoinsPlayerPrefsKey = "CollectedCoins";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            soundManager.PlayCoinSound();

            SaveManager.instance.money += 1;
            SaveManager.instance.Save();
        }
    }
}
