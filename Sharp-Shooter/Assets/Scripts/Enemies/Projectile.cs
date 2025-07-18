using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] GameObject projectileHitVFX;

    const string PICKUPS_TAG = "Pickups";

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
        if (!other.CompareTag(PICKUPS_TAG)) {

            Instantiate(projectileHitVFX, transform.position, Quaternion.identity);

            PlayerHealth playerHealth = other.GetComponentInParent<PlayerHealth>();
            EnemyHealth enemyHealth = other.GetComponentInParent<EnemyHealth>();
            ExplodingBarrel explodingBarrel = other.GetComponent<ExplodingBarrel>();

            enemyHealth?.TakeDamage(damage);
            playerHealth?.TakeDamage(damage);
            explodingBarrel?.TakeDamage(damage);
            
            Destroy(this.gameObject);
        }
    }
}
