using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class Projectile : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] GameObject projectileHitVFX;

    int damage;
    Rigidbody rb;
    bool hasHit = false;

    string[] ignoredTags = { "Pickups", "Ignore Raycast" };

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
        if (hasHit || ignoredTags.Contains(other.tag)) return;
        hasHit = true;

        Instantiate(projectileHitVFX, transform.position, Quaternion.identity);

        PlayerHealth playerHealth = other.GetComponentInParent<PlayerHealth>();
        EnemyHealth enemyHealth = other.GetComponentInParent<EnemyHealth>();
        ExplodingBarrel explodingBarrel = other.GetComponent<ExplodingBarrel>();
        DestroyableObject destroyableObject = other.GetComponent<DestroyableObject>();

        enemyHealth?.TakeDamage(damage);
        playerHealth?.TakeDamage(damage);
        explodingBarrel?.TakeDamage(damage);
        destroyableObject?.TakeDamage(damage);

        Destroy(gameObject);
    }

}
