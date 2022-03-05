using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

public class MapController : MonoSingleton<MapController>
{
    [SerializeField]
    private Vector2 mapSize;

    public Vector2 MapSize => mapSize;


    private void Start()
    {
        transform.localScale = new Vector3(mapSize.x, 0, mapSize.y);
    }
}
