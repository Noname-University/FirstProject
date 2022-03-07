using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    [SerializeField]
    private CollectableType[] collectables;

    [SerializeField]
    private Transform collectableParent;

    
    private void Start() {
        foreach (var collectable in collectables)
        {
            StartCoroutine(SpawnLoop(collectable));
        }
    }

    private IEnumerator SpawnLoop(CollectableType collectableType){
        float xPosition = Random.Range(-MapController.Instance.MapSize.x * 5, MapController.Instance.MapSize.x * 5);
        float zPosition = Random.Range(-MapController.Instance.MapSize.y * 5, MapController.Instance.MapSize.y * 5);

        Instantiate(collectableType.Prefab, new Vector3(xPosition, 0, zPosition), Quaternion.identity, collectableParent);

       // LeanTween.delayedCall(collectableType.SpawnTime,()=> SpawnLoop(collectableType));
        yield return new WaitForSeconds(collectableType.SpawnTime);
        StartCoroutine(SpawnLoop(collectableType));
       
    }
}

  [System.Serializable]
    struct CollectableType{
        [SerializeField]
        private GameObject prefap;

        [SerializeField]
        private float spawnTime;


        public GameObject Prefab => prefap;
        public float SpawnTime => spawnTime;

    }