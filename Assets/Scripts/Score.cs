using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text scorTxt;
    public int actualScore = 0;
    void Start()
    {
        scorTxt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        PrintScore();
    }

    public void AddToScore()
    {
        actualScore++;
    }

    void PrintScore()
    {
        scorTxt.text = "Score: " + actualScore;
    }
}
