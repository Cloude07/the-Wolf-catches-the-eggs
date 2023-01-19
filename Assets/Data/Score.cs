using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Text scoreText;
    [SerializeField] Text hiScoreText;
    public int hiScore;

    private void Start()
    {
        scoreText.text = "0";

        if (PlayerPrefs.HasKey("HighScore"))
        {
            hiScore = PlayerPrefs.GetInt("HighScore");
        }
        PlayerPrefs.SetInt("HighScore", hiScore);
    }
    private void OnEnable()
    {
        player.OnChangeScore += ScoreInputText;
    }

    private void ScoreInputText(int score)
    {
        scoreText.text = $"{score}";
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    private void OnDisable()
    {
        player.OnChangeScore -= ScoreInputText;
    }

    private void Update()
    {

        hiScoreText.text = $"Hi: {hiScore}";

    }
}
