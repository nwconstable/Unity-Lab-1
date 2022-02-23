using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongRock : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Transform ballTransform;
    [SerializeField] private float startSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Restart();
    }

    public void Restart() {
        rb.position = Vector2.zero;
        rb.velocity = Vector2.zero;
        StartCoroutine(ThrowRock());
    }

    IEnumerator ThrowRock() {
        yield return new WaitForSeconds(1);
        Vector2 newVelocity = new Vector2(Random.Range(0f, 5f), Random.Range(0f, 1f));
        rb.velocity = newVelocity.normalized * startSpeed;
    }
}
