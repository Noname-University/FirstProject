using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour, ICollectable
{
    public void Collect()
    {
        UIController.Instance.DecreaseScore();
        Destroy(gameObject);

    }
}
