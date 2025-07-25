using UnityEngine;
using System.Linq;

public class Projectile : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] GameObject projectileHitVFX;

    string[] ignoredTags = { "Pickups", "Ignore Raycast" };

    int damage;
    Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    void Start() {
        rb.linearVelocity = transform.forward * speed;
    }

    public void Init(int damage) {
        this.damage = damage;
    }

    void OnTriggerEnter(Collider other) {
        if (!ignoredTags.Contains(other.tag)) {

            Instantiate(projectileHitVFX, transform.position, Quaternion.identity);

            PlayerHealth playerHealth = other.GetComponentInParent<PlayerHealth>();
            EnemyHealth enemyHealth = other.GetComponentInParent<EnemyHealth>();
            ExplodingBarrel explodingBarrel = other.GetComponent<ExplodingBarrel>();
            DestroyableObject destroyableObject = other.GetComponent<DestroyableObject>();

            enemyHealth?.TakeDamage(damage);
            playerHealth?.TakeDamage(damage);
            explodingBarrel?.TakeDamage(damage);
            destroyableObject?.TakeDamage(damage);
            
            Destroy(this.gameObject);
        }
    }
}
