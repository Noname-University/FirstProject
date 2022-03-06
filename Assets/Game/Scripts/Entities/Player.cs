using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;
using System;

public class Player : MonoSingleton<Player>, IKillable
{
  
   [SerializeField]
    private float speed;

     [SerializeField]
    private float jumpSpeed;

    [SerializeField]
    private Transform jumpControlPoint;


    private float health = 100;


    private Rigidbody rb;

    public event Action<float> PlayerHealthDecraese;


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
        var desiredPositionX = Mathf.Clamp
        (
            transform.position.x +  Input.GetAxis("Horizontal") * speed * Time.deltaTime,
            -MapController.Instance.MapSize.x * 5,
             MapController.Instance.MapSize.x * 5
        );

        var desiredPositionZ = Mathf.Clamp
        (
            transform.position.z + Input.GetAxis("Vertical") * speed * Time.deltaTime,
            -MapController.Instance.MapSize.y * 5,
             MapController.Instance.MapSize.y * 5
        );
      transform.position = new Vector3(desiredPositionX, transform.position.y, desiredPositionZ);
        

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

        PlayerHealthDecraese?.Invoke(hitPoint);
    }

    public void Kill()
    {
       Time.timeScale = 0;
    }
}