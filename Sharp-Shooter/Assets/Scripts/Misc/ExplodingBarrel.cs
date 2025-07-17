using UnityEngine;

public class ExplodingBarrel : MonoBehaviour {

    [SerializeField] int startingHealth;
    [SerializeField] GameObject explosionVFX;
    
    int currentHealth;

    void Awake() {
        currentHealth = startingHealth;
    }

    public void ReceiveDamage(int amount){
        currentHealth -= amount;

        if (currentHealth <= 0){
            DestroyObject();
        }
    }

    void DestroyObject() {
        Destroy(this.gameObject);
        Instantiate(explosionVFX, transform.position, Quaternion.identity);
    }
}
