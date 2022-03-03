using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FPSPlayer : MonoBehaviour
{
    [SerializeField] private Transform shootPosition;
    [SerializeField] private Transform head;
    [SerializeField] private GameObject bullet;
    [SerializeField] private AudioSource shootSound;
    [SerializeField] private UI fpsUI;
    [SerializeField] private int maxHealth;
    private float lastHitTime;
    [SerializeField] private float rateOfFire;
    private float lastShot;
    private int health;
    private int enemyDefeatCount;
    public static FPSPlayer instance;

    private int Health{
        get {
            return health;
        }
        set {
            health = value;
            fpsUI.ShowHealthFraction((float)Health / (float)maxHealth);
            if (health <= 0) {
                LoadingScreen.LoadScene("MainMenu");
            }
        }
    }

    void Awake() {
        instance = this;
        Health = maxHealth;
    }
    
    void Update()
    {
        if (Input.GetMouseButton(0) && (lastShot > rateOfFire)) {
            Fire();
            lastShot = 0;
        }
        lastShot += Time.deltaTime;
    }

    private void Fire() {
        // Instantiate a bullet
        GameObject newBullet = Instantiate(bullet);
        // Set the bullet's position
        newBullet.transform.SetPositionAndRotation(shootPosition.position, shootPosition.rotation);
        shootSound.Play();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.gameObject.CompareTag("Enemy") && (Time.time - lastHitTime > 0f)) {
            lastHitTime = Time.time;
            Destroy(hit.gameObject);
            TakeDamage();
        }
    }

    private void TakeDamage() {
        if (Health > 0) {
            Health--;
        }
    }

    public void HandleEnemyDefeat() {
        enemyDefeatCount++;
        fpsUI.ShowEnemyCount(enemyDefeatCount);
    }

    public bool ShouldSpawn(Vector3 pos){
        Vector3 posDiff = pos - transform.position;
        Vector3 faceDirection = head.forward;
        float distanceFromPlayer = posDiff.magnitude;
        return ((Vector3.Dot(posDiff.normalized, faceDirection) < 0.5f) && distanceFromPlayer > 10f);
    }
}
