using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;

public class MapController : MonoSingleton<MapController>
{
 [SerializeField]
 private Vector2 mapSize;

 [SerializeField]
 private Transform plane;

 public Vector2 MapSize => mapSize;

 
 private void Start()
 {
     plane.localScale = new Vector3(mapSize.x, 1,mapSize.y);
 }
}
