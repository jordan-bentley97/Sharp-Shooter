using UnityEngine;
using System.Collections.Generic;

public class BarrelExplosion : MonoBehaviour {
    [SerializeField] float radius = 1.5f;
    [SerializeField] int damage;
    
    const string PLAYER_STRING = "Player";

    void Start() {
        Explode();
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void Explode() {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        HashSet<object> damaged = new HashSet<object>(); //adds an object to a dictionary, checks that object hasnt been damaged already before damaging

        foreach (Collider hitCollider in hitColliders) {
            PlayerHealth playerHealth = hitCollider.GetComponent<PlayerHealth>();

            if (playerHealth != null && !damaged.Contains(playerHealth)) {
                playerHealth.TakeDamage(damage);
                damaged.Add(playerHealth);
            }

            EnemyHealth enemyHealth = hitCollider.GetComponent<EnemyHealth>();

            if (enemyHealth != null && !damaged.Contains(enemyHealth)) {
                enemyHealth.TakeDamage(damage);
                damaged.Add(enemyHealth);
            }
        }
    }
}
