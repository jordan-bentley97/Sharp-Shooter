using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    [SerializeField] int startingHealth;
    [SerializeField] GameObject explosionVFX;

    GameManager gameManager;
    int currentHealth;

    void Awake() {
        currentHealth = startingHealth;
    }

    void Start() { 
        gameManager = FindFirstObjectByType<GameManager>();
        gameManager.AdjustEnemiesRemaining(1); 
        // will run when an enemy is instanced
    }

    public void TakeDamage(int amount){
        currentHealth -= amount;

        if (currentHealth <= 0){
            SelfDestruct();
        }
    }

    public void SelfDestruct() {
        Instantiate(explosionVFX, transform.position, Quaternion.identity);
        gameManager.AdjustEnemiesRemaining(-1);
        Destroy(this.gameObject);
    }
}
