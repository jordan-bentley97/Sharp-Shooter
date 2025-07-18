using System.Collections;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{

    [SerializeField] int startingHealth;
    [SerializeField] GameObject destroyedObjectPrefab;

    int currentHealth;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            DestroyObject();
        }
    }

    void DestroyObject()
    {
        Destroy(this.gameObject);
        Instantiate(destroyedObjectPrefab, transform.position, Quaternion.identity);
    }

}
