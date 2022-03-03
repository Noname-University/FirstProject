using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoSingleton<UIController>
{
    [SerializeField]
    private GameObject startPanel;

    [SerializeField]
    private GameObject finalPanel;

    [SerializeField]
    private GameObject inGamePanel;

    [SerializeField]
    private Text score;

    [SerializeField]
    private Text currentScoreFinal;

    [SerializeField]
    private Text maxScoreFinal;


    private int scoreCount = 0;
    private int maxScore = 0;

    private void Start() {
        score.text = scoreCount.ToString();
        Time.timeScale = 0;
        OpenStartGamePanel();
    }

    public void IncreaseScore(){
        scoreCount++;
        score.text = scoreCount.ToString();
        if (scoreCount > maxScore)
        {
            maxScore = scoreCount;
        }
    }

    public void DecreaseScore(){
        scoreCount--;
        if (scoreCount <= 0)
        {
            Time.timeScale = 0;
            OpenFinalGamePanel();
            maxScoreFinal.text = "Max Score: " + maxScore.ToString();
            return;
        }
        score.text = scoreCount.ToString();
    }

    public void PlayButtonDown(){
        Time.timeScale = 1;
        OpenInGamePanel();
    }

    public void RestartButtonDown(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    #region Panels
    private void OpenInGamePanel(){
        inGamePanel.SetActive(true);
        finalPanel.SetActive(false);
        startPanel.SetActive(false);
    }
    private void OpenFinalGamePanel(){
        inGamePanel.SetActive(false);
        finalPanel.SetActive(true);
        startPanel.SetActive(false);
    }
    private void OpenStartGamePanel(){
        inGamePanel.SetActive(false);
        finalPanel.SetActive(false);
        startPanel.SetActive(true);
    }

    #endregion
}
