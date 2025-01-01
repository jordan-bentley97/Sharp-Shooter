using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour {

    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform turretHead;
    [SerializeField] Transform playerTargetPoint;
    [SerializeField] Transform projectileSpawnPoint;
    [SerializeField] float fireRate;
    [SerializeField] int damage;
    [SerializeField] ParticleSystem muzzleflash;

    PlayerHealth player;

    AudioSource audioSource;

    void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    void Start() {
        player = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(FireRoutine());
    }

    void Update() {
        turretHead.LookAt(playerTargetPoint);
    }

    IEnumerator FireRoutine() {
        while (player) {
            yield return new WaitForSeconds(fireRate);
            Projectile newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity).GetComponent<Projectile>();
            newProjectile.transform.LookAt(playerTargetPoint);
            newProjectile.Init(damage);
            muzzleflash.Play();
            audioSource.Play();
        }
    }
}
