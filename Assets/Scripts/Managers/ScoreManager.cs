using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.MLAgents;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text Text;
    public string HighScoreText = "HIGH SCORE:";
    public int Total = 0;
    int HighScore = 0;

    public void UpdateHighScore(int score)
    {
        Total += score;

        if (Total > HighScore)
        {
            HighScore = Total;

            Text.text = $"{HighScoreText} {Total}";
            Text.color = Color.red;
        }
    }
}
