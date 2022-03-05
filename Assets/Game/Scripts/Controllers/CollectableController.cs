using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    [SerializeField]
    private CollectableType[] collectables;




    private void Update()
    {
        foreach (var collectable in collectables)
        {
            Instantiate(collectable.Prefab, new Vector3(0, 0, 0), Quaternion.identity);
            
        }
    }

    private void SpawnLoop()
    {

    }
}

[System.Serializable]
struct CollectableType
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private float spawnTime;

    public float Timer;


    public GameObject Prefab => prefab;
    public float SpawnTime => spawnTime;
}
