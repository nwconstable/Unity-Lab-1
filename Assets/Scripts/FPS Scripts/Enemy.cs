using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform mainTransform;
    [SerializeField] private float moveSpeed;
    
    void Update()
    {
        Vector3 playerPos = FPSPlayer.instance.transform.position;
        FacePlayer(playerPos);
        MoveToPlayer(playerPos);
    }

    private void FacePlayer(Vector3 playerPos){
        mainTransform.LookAt(playerPos);
        Vector3 currentRotation = mainTransform.rotation.eulerAngles;
        currentRotation.x = 0;
        mainTransform.eulerAngles = currentRotation;
    }
    
    private void MoveToPlayer(Vector3 playerPos){
        Vector3 directionToPlayer = (playerPos - mainTransform.position).normalized;
        mainTransform.position += (directionToPlayer * moveSpeed * Time.deltaTime).SetY(0);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Bullet")) {
            Destroy(gameObject);
            Destroy(other.gameObject);
            FPSPlayer.instance.HandleEnemyDefeat();
        }
    }
}
