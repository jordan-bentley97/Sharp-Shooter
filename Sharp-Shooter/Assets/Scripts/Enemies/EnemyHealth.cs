using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    [SerializeField] public int startingHealth;
    [SerializeField] GameObject explosionVFX;
    [SerializeField] bool hasHealthBar;

    GameManager gameManager;
    int currentHealth;
    Healthbar healthbar;
    
    void Awake() {
        currentHealth = startingHealth;
        if (hasHealthBar) {
            healthbar = GetComponentInChildren<Healthbar>();
        }
    }

    void Start() { 
        gameManager = FindFirstObjectByType<GameManager>();
        gameManager.AdjustEnemiesRemaining(1);
    }

    public void TakeDamage(int amount){
        currentHealth -= amount;

        if (hasHealthBar)
        {
            healthbar.SetHealth(currentHealth);
        }

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
