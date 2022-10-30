using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text HighScore;
    public string HighScoreText = "HIGH SCORE:";

    public void UpdateHighScore(int Score)
    {
        Score += Score;
        Debug.Log(Score);
        HighScore.text = $"{HighScoreText} {Score}";
        HighScore.color = Color.red;
    }
}
