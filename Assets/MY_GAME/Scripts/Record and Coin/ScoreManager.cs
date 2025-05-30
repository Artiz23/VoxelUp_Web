using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text HighScoreText;
    [SerializeField] Text ScoreText;

    public static float score;
    private SaveManager saveManager;

    void Start()
    {
        saveManager = GameObject.FindWithTag("SaveManager").GetComponent<SaveManager>();

        score = 0;

        UpdateHighScoreText();
    }

    void Update()
    {
        if (ScoreText != null)
        {
            ScoreText.text = ((int)score).ToString();
        }

        if ((int)score > saveManager.highscore)
        {
            saveManager.highscore = (int)score;
            PlayerPrefs.SetInt("score", saveManager.highscore);
            UpdateHighScoreText();
        }
    }

    void UpdateHighScoreText()
    {
        if (HighScoreText != null)
        {
            HighScoreText.text = saveManager.highscore.ToString();
        }
    }
}
