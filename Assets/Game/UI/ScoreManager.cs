using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : Manager<ScoreManager>
{
    public Text ScoreText;

    public HealthPanel HealthPanel01;
    public HealthPanel HealthPanel02;

    private int CurrentScore;

    private void Start()
    {
        HealthPanel01.gameObject.SetActive(false);
        HealthPanel02.gameObject.SetActive(false);
    }

    public HealthPanel EnablePanel(int index)
    {
        if(index == 1) {
            HealthPanel01.gameObject.SetActive(true);
            return HealthPanel01;
        }else if(index == 2) {
            HealthPanel02.gameObject.SetActive(true);
            return HealthPanel02;
        }

        return null;
    }

    public void AddScore(int score)
    {
        CurrentScore += score;
        ScoreText.text = CurrentScore.ToString("D8");
    }
}
