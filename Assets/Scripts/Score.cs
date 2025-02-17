using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI uiScoreText;
    public TextMeshProUGUI gameOverScoreText;

    public void AddEnemyScore()
    {
        score += 25;
        UpdateScoreText();
    }

    public void AddAsteroidScore()
    {
        score += 10;
        UpdateScoreText();
    }

    public void AddBulletScore()
    {
        score += 10;
        UpdateScoreText();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (uiScoreText != null)
        {
            uiScoreText.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.LogWarning("Score text not assigned.");
        }

        if (gameOverScoreText != null)
        {
            gameOverScoreText.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.LogWarning("Game Over Score text not assigned.");
        }
    }

    public int GetScore()
    { 
        return score;
    }
}
