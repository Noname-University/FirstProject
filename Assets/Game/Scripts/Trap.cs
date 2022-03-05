using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour, ICollectable
{
    [SerializeField]
    private float damage;
    public void Collect()
    {
        Player.Instance.HealtDecraese(damage);
        Destroy(gameObject);
    }
}
