using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Helpers;

public class UIController : MonoSingleton<UIController>
{
 [SerializeField]
  private RectTransform healthBarHandler;

 [SerializeField]
 private CanvasGroup hitCallbackPanel;

 private Color hitColor;

    private void Start() 
    {
        Player.Instance.PlayerHealthDecraese += OnPlayerHealthDecraese;
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
}
