using UnityEngine;

public class Explosion : MonoBehaviour {

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
        foreach (Collider hitCollider in hitColliders) {
            PlayerHealth playerHealth = hitCollider.GetComponent<PlayerHealth>();

            if (!playerHealth) continue; //skips the current iteration (and doesnt execute rest of code) of the for loop if script is NOT found on a collider

            playerHealth.TakeDamage(damage);

            break; //exits the for loop entirely
        }
    }
}
