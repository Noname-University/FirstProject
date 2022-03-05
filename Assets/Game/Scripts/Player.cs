using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;

public class Player : MonoSingleton<Player>, IKillable
{
  
   [SerializeField]
    private float speed;

     [SerializeField]
    private float jumpSpeed;

    [SerializeField]
    private Transform jumpControlPoint;

    [SerializeField]

    private float health;


    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }
    void Update()
    {
      Movement();
    }

    private void   OnTriggerEnter(Collider other) 
    {
         var collectable =  other.GetComponent<ICollectable>();
        if(collectable != null)
        {
            collectable.Collect();
        }

    }
    private void Movement()
    {
      transform.position += new Vector3(
            Input.GetAxis("Horizontal") * speed * Time.deltaTime,
            0,
            Input.GetAxis("Vertical") * speed * Time.deltaTime
         );

         if (Input.GetKeyDown(KeyCode.Space))
         {
            if(Physics.Raycast(jumpControlPoint.position, Vector3.down, 0.1f))
            {
                rb.AddForce(Vector3.up * jumpSpeed);
            }
         }
    }

    public void Healthdecrase(float hitPoint)
    {
        health -= hitPoint;
        
        if(health <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
       Time.timeScale = 0;
    }
}
