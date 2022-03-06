using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;
//using UnityEngine.UI eklenecek
public class UIController : MonoSingleton<UIController>
{
    [SerializeField]
    private CanvasGroup hitCallbackPanel;
    [SerializeField]
    private RectTransform healtBarHandler;

    private void Start()
    {
        Player.Instance.PlayerHealtDecrease += OnPlayerHealtDecrease; // Action kaydetme
    }
    private void Update()
    {

    }

    public void OnPlayerHealtDecrease(float value)
    {

        healtBarHandler.localScale = new Vector3(healtBarHandler.localScale.x - value / 100, 1, 1);

        LeanTween.alphaCanvas(hitCallbackPanel, .5f, .3f).setLoopPingPong(1);
    }
}
