using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoSingleton<UIController>
{
    [SerializeField]
    private GameObject startPanel;

    [SerializeField]
    private GameObject inGamePanel;

    [SerializeField]
    private GameObject finalPanel;

    [SerializeField]
    private Text score;

    [SerializeField]
    private Text maxScoreFinal;

    private int scoreCount = 0;
    private int maxScore = 0;

    private void Start() 
    {
        score.text = scoreCount.ToString();
        Time.timeScale = 0;
        OpenStartPanel();
    }

    public void IncreaseScore()
    {
        scoreCount++;
        score.text = scoreCount.ToString();

        if(scoreCount > maxScore)
        {
            maxScore = scoreCount;
        }
    }

    public void DecreaseScore()
    {
        scoreCount--;

        if(scoreCount < 1)
        {
            Time.timeScale = 0;
            OpenFinalPanel();

            maxScoreFinal.text = "Max Score: " + maxScore.ToString();
            return;
        }

        score.text = scoreCount.ToString();
    }

    public void PlayButtonDown()
    {
        Time.timeScale = 1;
        OpenInGamePanel();
    }

    public void RestartButtonDown()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    #region Panels

    private void OpenInGamePanel()
    {
        inGamePanel.SetActive(true);
        startPanel.SetActive(false);
        finalPanel.SetActive(false);
    }

    private void OpenStartPanel()
    {
        inGamePanel.SetActive(false);
        startPanel.SetActive(true);
        finalPanel.SetActive(false);
    }

    private void OpenFinalPanel()
    {
        inGamePanel.SetActive(false);
        startPanel.SetActive(false);
        finalPanel.SetActive(true);
    }

    #endregion
}
