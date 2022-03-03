using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldController : MonoBehaviour
{
    [SerializeField]
    private GameObject goldPrefab;

    [SerializeField]
    private Vector2 min;

    [SerializeField]
    private Vector2 max;

    [SerializeField]
    private float timer;

    private float counter;

    private void Start() {
        counter=timer;
    }
    private void Update() {
        counter-=Time.deltaTime;

        if (counter <= 0)
        {
            counter = timer;
            var xPossition = Random.Range(min.x, max.x);
            var zPossition = Random.Range(min.y, max.y);

            Instantiate(goldPrefab, new Vector3(xPossition,0,zPossition),Quaternion.identity);
        }
    }
}
