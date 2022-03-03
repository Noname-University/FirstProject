using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoSingleton<UIController>
{
    [SerializeField]
    private Text score;

    private int scoreCount = 0;

    private void Start() {
        score.text = scoreCount.ToString();
    }

    public void IncreaseScore(){
        scoreCount++;
        score.text = scoreCount.ToString();
    }
}
