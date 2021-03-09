using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    [SerializeField] private Image kingBar, opponentBar;
    [SerializeField] private ScoreManager _scoreManager;
    private int ok, bad;
    public int[] totalKingNotes = { 0, 0, 0, 575, 0 }; //TODO:

    public void OK()
    {
        ok++;
        kingBar.fillAmount = (float)ok / totalKingNotes[_scoreManager.difficulty];
        opponentBar.fillAmount = (float)bad / totalKingNotes[_scoreManager.difficulty];
    }

    public void Bad()
    {
        bad++;
        kingBar.fillAmount = (float)ok / totalKingNotes[_scoreManager.difficulty];
        opponentBar.fillAmount = (float)bad / totalKingNotes[_scoreManager.difficulty];
    }

    public void Init()
    {
        ok = 0;
        bad = 0;
        kingBar.fillAmount = 0;
        opponentBar.fillAmount = 0;
    }
}
