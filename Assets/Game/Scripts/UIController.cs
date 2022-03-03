using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoSingleton<UIController>
{
    [SerializeField]
    private Text score;



    private int scoreIndex = 0;

    private void Start() 
    {
        score.text = scoreIndex.ToString();
    }

    public void IncreaseScore()
    {
        scoreIndex++;
        score.text = scoreIndex.ToString();
    }
}
