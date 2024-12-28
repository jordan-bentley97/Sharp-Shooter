using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    [SerializeField] int startingHealth;
    [SerializeField] GameObject explosionVFX;
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
        Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
