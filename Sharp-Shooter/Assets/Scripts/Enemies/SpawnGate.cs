using System.Collections;
using StarterAssets;
using UnityEngine;

public class SpawnGate : MonoBehaviour {

    [SerializeField] int spawnTime;
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] ParticleSystem spawnGateVFX;

    PlayerHealth player;

    void Start() {
        player = FindFirstObjectByType<PlayerHealth>();
        if (FindAnyObjectByType<FirstPersonController>()) {
           StartCoroutine(SpawnRoutine());
        }
    }

    IEnumerator SpawnRoutine() {
        while (player) {
            Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], spawnPoint.position, Quaternion.identity);
            spawnGateVFX.Play();
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
