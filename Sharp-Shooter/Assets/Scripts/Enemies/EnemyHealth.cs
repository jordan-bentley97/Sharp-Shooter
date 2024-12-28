using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    [SerializeField] int startingHealth;
    [SerializeField] GameObject robotExplosionVFX;
    int currentHealth;

    void Awake() {
        currentHealth = startingHealth;
    }

    public void takeDamage(int amount){
        currentHealth -= amount;

        if (currentHealth <= 0){
            SelfDestruct();
        }
    }


    public void SelfDestruct() {
        Instantiate(robotExplosionVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
