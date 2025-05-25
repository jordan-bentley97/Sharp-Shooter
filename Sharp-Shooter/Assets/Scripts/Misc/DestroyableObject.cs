using UnityEngine;

public class DestroyableObject : MonoBehaviour {

    [SerializeField] int startingHealth;
    [SerializeField] GameObject destroyedObject;
    
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
        Instantiate(destroyedObject, transform.position, Quaternion.identity);
    }
}
