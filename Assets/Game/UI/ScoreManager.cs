using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : Manager<ScoreManager>
{
    public Text ScoreText;

    private int CurrentScore;

    public void AddScore(int score)
    {
        CurrentScore += score;
        ScoreText.text = CurrentScore.ToString("D8");
    }
}
