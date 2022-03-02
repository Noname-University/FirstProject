using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    [SerializeField]
    private float speed;

    void Update()
    {
        transform.Rotate(0,speed*Time.deltaTime,0);
    }

    public void Collect(){
        Destroy(gameObject);
    }
}