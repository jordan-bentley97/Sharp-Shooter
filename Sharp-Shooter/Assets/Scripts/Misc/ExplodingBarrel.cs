using System.Collections;
using UnityEngine;

public class ExplodingBarrel : MonoBehaviour {

    [SerializeField] int startingHealth;
    [SerializeField] GameObject explosionVFX;
    [SerializeField] float explosionDelay;
    
    int currentHealth;
    ParticleSystem ps;

    void Awake()
    {
        currentHealth = startingHealth;
        ps = GetComponentInChildren<ParticleSystem>();
    }

    public void TakeDamage(int amount){
        currentHealth -= amount;

        if (currentHealth <= 0){
            StartCoroutine(Explosion());
        }
    }

    IEnumerator Explosion() {
        ps.Play();
        yield return new WaitForSeconds(explosionDelay);
        Destroy(this.gameObject);
        Instantiate(explosionVFX, transform.position, Quaternion.identity);
    }
}
