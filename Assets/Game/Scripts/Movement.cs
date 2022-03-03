using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
     private float speed;
     [SerializeField]
     private float jumpSpeed;
     [SerializeField]
     private Transform jumpControlPoint;

    private Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        transform.position += new Vector3
        (
            Input.GetAxis("Horizontal") * speed * Time.deltaTime,
            0,
          Input.GetAxis("Vertical") * speed * Time.deltaTime

        );

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(jumpControlPoint.position,Vector3.down,0.1f))
            {
                rb.AddForce(Vector3.up * jumpSpeed);

            }
        }

    }
    
    private void OnTriggerEnter(Collider other) {
        var gold = other.GetComponent<Gold>();
        if (gold != null)
        {
            UIController.Instance.IncreaseScore();
            gold.Collect();
        }
    }
}