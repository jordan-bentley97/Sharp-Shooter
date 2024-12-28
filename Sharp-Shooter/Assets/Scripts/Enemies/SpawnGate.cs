using System.Collections;
using StarterAssets;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{

    [SerializeField] int spawnTime;
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject robotPrefab;

    PlayerHealth player;

    void Start() 
    {
        player = FindFirstObjectByType<PlayerHealth>();
        if (FindAnyObjectByType<FirstPersonController>()) 
        {
           StartCoroutine("SpawnRoutine");
        }
    }

    IEnumerator SpawnRoutine()
    {

        while (player)
        {
            Instantiate(robotPrefab, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }

    }


}
