using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField]
    private float speed;
    void Update()
    {
        transform.position += new Vector3(
            Input.GetAxis("Horizontal") * speed * Time.deltaTime,
            0,
            Input.GetAxis("Vertical") * speed * Time.deltaTime
        );
    }

    private void   OnTriggerEnter(Collider other) 
    {
        var collectable =  other.GetComponent<ICollectable>();
        if(collectable != null)
        {
            collectable.Collect();
        }
    }
}
