using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{

    public int highScore;

    void Start()
    {
        
    }

    

    public void Display(int score)
    {
        GetComponent<Text>().text = "High score: " + score;
    }
}
