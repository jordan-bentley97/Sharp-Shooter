using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] GameObject projectileVFX;

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
        Instantiate(projectileVFX, transform.position, Quaternion.identity);
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        playerHealth?.TakeDamage(damage);
        Destroy(this.gameObject);
    }
}
