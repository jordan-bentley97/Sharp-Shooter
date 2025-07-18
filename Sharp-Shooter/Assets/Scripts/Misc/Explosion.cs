using UnityEngine;
using Cinemachine;

public class Explosion : MonoBehaviour {

    [SerializeField] float radius = 1.5f;
    [SerializeField] int damage;
    
    const string PLAYER_STRING = "Player";

    CinemachineImpulseSource impulseSource;

    void Awake() {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    void Start() {
        Explode();
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void Explode() {

        impulseSource.GenerateImpulse();

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        
        foreach (Collider hitCollider in hitColliders) {
            PlayerHealth playerHealth = hitCollider.GetComponent<PlayerHealth>();

            if (!playerHealth) continue;

            playerHealth.TakeDamage(damage);

            break;
        }
    }
}
