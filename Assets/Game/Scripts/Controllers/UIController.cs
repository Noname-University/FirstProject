using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoSingleton<UIController>
{
    [SerializeField]
    private RectTransform healthBarHandler;

    [SerializeField]
    private CanvasGroup hitCallBackPanel;


    private void Start() {
        Player.Instance.PlayerHealthDecrase += OnPlayerHealthDecrase;
    }

    public void OnPlayerHealthDecrase(float value){
        healthBarHandler.localScale = new Vector3(healthBarHandler.localScale.x - value / 100, 1, 1);
        LeanTween.alphaCanvas(hitCallBackPanel,.5f,.3f).setLoopPingPong(1);
    }

}
