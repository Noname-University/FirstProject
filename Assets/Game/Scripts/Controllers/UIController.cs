using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Helpers;
using UnityEngine.SceneManagement;

public class UIController : MonoSingleton<UIController>
{
 [SerializeField]
  private RectTransform healthBarHandler;

 [SerializeField]
 private CanvasGroup hitCallbackPanel;

 [SerializeField]
 private Image deadPanel;

 [SerializeField]
 private Image inGamePanel;

 private Color hitColor;

    private void Start() 
    {
        Player.Instance.PlayerHealthDecraese += OnPlayerHealthDecraese;
        Player.Instance.PlayerDead += OnPlayerDead;

        Time.timeScale = 1  ;
        openInGamePanel();
    }
  
  public void OnPlayerHealthDecraese(float value)
  {
      healthBarHandler.localScale = new Vector3
      (
          healthBarHandler.localScale.x - value /100,
          1,
          1
    );

    LeanTween.alphaCanvas(hitCallbackPanel,.5f,.1f).setLoopPingPong(1);
  }

  private void OnPlayerDead()
  {
    openDeadPanel();
  }

  private void openDeadPanel()
  {
    deadPanel.gameObject.SetActive(true);
    inGamePanel.gameObject.SetActive(false);
  }

  private void openInGamePanel()
  {
    deadPanel.gameObject.SetActive(false);
    inGamePanel.gameObject.SetActive(true);
  }
  public void Restart()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
