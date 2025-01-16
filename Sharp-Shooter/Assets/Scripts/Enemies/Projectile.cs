using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] GameObject projectileVFX;

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
            Instantiate(projectileVFX, transform.position, Quaternion.identity);
            PlayerHealth playerHealth = other.GetComponentInParent<PlayerHealth>();
            playerHealth?.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
