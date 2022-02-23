using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private SpawnObject objectPrefab;
    [SerializeField] private TMP_Text objectCountText;
    private int objectCount = 0;
    
    void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            for(int i =0; i < 1000; i++) {
                SpawnObject newObject = Instantiate(objectPrefab);
                newObject.SetColor(Random.ColorHSV(0, 1, 0.75f, 1, 0.5f, 1, 1, 1));
                newObject.transform.position = spawnLocation.position;
                newObject.transform.rotation = Random.rotation;
                objectCount++;
                objectCountText.text = objectCount.ToString() + " monkeys";
            }
        }
    }
}
