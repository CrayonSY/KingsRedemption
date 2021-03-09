using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    //public int[] highScores = new int[4];
    public int difficulty;
    [SerializeField] private Text text;
    [SerializeField] private SoundController _soundController;
    //[SerializeField] private Text[] _highScoreTexts;

    public void Init()
    {
        score = 0;
        text.text = "Score: " + score;
    }

    public void RaiseScore(int plusScore)
    {
        score += plusScore;
        text.text = "Score: " + score;
        if (score % 1000 == 0) _soundController.PlaySE(3);
        else if (score % 100 == 0) _soundController.PlaySE(2);
        else if (score % 10 == 0) _soundController.PlaySE(1);
        else _soundController.PlaySE(0);
    }

    public void DisplayHighScore()
    {
        //if (highScores[difficulty] < score) highScores[difficulty] = score;
        //_highScoreTexts[difficulty].text = "High score: " + highScores[difficulty];
    }
}
