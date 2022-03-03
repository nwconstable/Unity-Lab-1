using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform mainTransform;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireRoutine());
    }

    IEnumerator FireRoutine() {
        float elapsedTime = 0;
        while (elapsedTime <= lifeTime) {
            elapsedTime += Time.deltaTime;
            mainTransform.position += mainTransform.forward * moveSpeed * Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
