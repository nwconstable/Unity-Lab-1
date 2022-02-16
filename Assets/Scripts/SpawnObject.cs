using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private AudioSource audioSource;

    public void SetColor(Color color){
        for(int i = 0; i < meshRenderer.materials.Length; i++){
            meshRenderer.materials[i].SetColor("_Color", color);
        }
    }

    private float lastHitTime = 0;
    private void OnCollisionEnter(Collision collision){
        if((Time.time - lastHitTime) > 0.25f) {
            lastHitTime = Time.time;
            audioSource.volume = Mathf.InverseLerp(0, 10, collision.relativeVelocity.magnitude);
            audioSource.pitch = Random.Range(0.75f, 1.25f);
            audioSource.Play();
        }
    }
}
