using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private void Update()
    {
        transform.position += new Vector3
        (
            Input.GetAxis("Horizontal") * speed * Time.deltaTime,
            0, 
            Input.GetAxis("Vertical") * speed * Time.deltaTime
        );
    }

    private void OnTriggerEnter(Collider other) 
    {
        var gold = other.GetComponent<Gold>();
        if(gold != null)
        {
            gold.Collect();
        }

    }
}
