using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public TMP_Text text;
    public string highScoreText = "HIGH SCORE:";
    public int total = 0;

    int highScore = 0;

    public void UpdateHighScore(int score)
    {
        total += score;

        if (total > highScore)
        {
            highScore = total;

            text.text = $"{highScoreText} {total}";
            text.color = Color.red;
        }
    }
}
