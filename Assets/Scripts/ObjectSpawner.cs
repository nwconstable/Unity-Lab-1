using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private SpawnObject objectPrefab;
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            SpawnObject newObject = Instantiate(objectPrefab);
        }
    }
}
