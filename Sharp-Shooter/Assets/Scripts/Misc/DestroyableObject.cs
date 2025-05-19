using UnityEngine;

public class DestroyableObject : MonoBehaviour {

    [SerializeField] public int startingHealth;
    [SerializeField] GameObject destroyedObject;
    
    int currentHealth;

    void Awake() {
        startingHealth = currentHealth;
    }

    public void ReceiveDamage(int amount){
        currentHealth -= amount;

        if (currentHealth <= 0){
            DestroyObject();
        }
    }

    void DestroyObject() {
        Instantiate(destroyedObject, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
