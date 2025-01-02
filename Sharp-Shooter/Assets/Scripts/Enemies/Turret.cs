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
    [SerializeField] float rotationSpeed = 2.0f;

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
        if (player) {
            Vector3 directionToPlayer = playerTargetPoint.position - turretHead.position;
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            turretHead.rotation = Quaternion.Lerp(turretHead.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            //turretHead.LookAt(playerTargetPoint); <- old method, rotates turret model too fast and player never sees it
        }
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
