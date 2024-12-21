using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    [SerializeField] int startingHealth;
    int currentHealth;

    void Awake() {
        currentHealth = startingHealth;
    }

    public void takeDamage(int amount){
        currentHealth -= amount;

        if (currentHealth <= 0){
            Death();
        }
    }

    void Death(){
        Destroy(this.gameObject);
    }
}
