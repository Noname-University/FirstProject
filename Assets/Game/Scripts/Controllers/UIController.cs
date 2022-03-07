using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoSingleton<UIController>
{
    [SerializeField]
    private RectTransform healthBarHandler;

    [SerializeField]
    private CanvasGroup hitCallBackPanel;

    [SerializeField]
    private Image inGamePanel;

    [SerializeField]
    private Image deadPanel;



    private void Start() {
        OpenInGamePanel();
        Time.timeScale = 1;
        Player.Instance.PlayerHealthDecrase += OnPlayerHealthDecrase;
        Player.Instance.PlayerDead += OnPlayerDead;
        

    }

    public void OnPlayerHealthDecrase(float value){
        healthBarHandler.localScale = new Vector3(healthBarHandler.localScale.x - value / 100, 1, 1);
        LeanTween.alphaCanvas(hitCallBackPanel,.5f,.3f).setLoopPingPong(1);
    }

    public void OnPlayerDead(){
        OpenDeadPanel();
    }

    public void OpenInGamePanel(){
        deadPanel.gameObject.SetActive(false);
        inGamePanel.gameObject.SetActive(true);
    }
    public void OpenDeadPanel(){
        deadPanel.gameObject.SetActive(true);
        inGamePanel.gameObject.SetActive(false);
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
