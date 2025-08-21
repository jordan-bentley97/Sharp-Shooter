using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    [SerializeField] public int startingHealth;
    [SerializeField] GameObject explosionVFX;

    GameManager gameManager;
    int currentHealth;
    Healthbar healthbar;
    
    void Awake() {
        currentHealth = startingHealth;
        healthbar = GetComponentInChildren<Healthbar>();

    }

    void Start() { 
        gameManager = FindFirstObjectByType<GameManager>();
        gameManager.AdjustEnemiesRemaining(1);
    }

    public void TakeDamage(int amount){
        currentHealth -= amount;

        healthbar.SetHealth(currentHealth);

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
