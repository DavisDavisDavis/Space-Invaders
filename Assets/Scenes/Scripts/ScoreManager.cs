using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.MLAgents;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text HighScore;
    public string HighScoreText = "HIGH SCORE:";
    int Total = 0;



    public void UpdateHighScore(int score)
    {
        Total += score;
        HighScore.text = $"{HighScoreText} {Total}";
        HighScore.color = Color.red;
    }
}
