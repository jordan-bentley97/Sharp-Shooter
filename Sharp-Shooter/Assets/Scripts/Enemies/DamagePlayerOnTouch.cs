using UnityEngine;

public class DamagePlayerOnTouch : MonoBehaviour {

    [SerializeField] int amount;

    const string PLAYER_STRING = "Player";

    PlayerHealth playerHealth;

    void Start () {
        playerHealth = FindFirstObjectByType<PlayerHealth>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag(PLAYER_STRING)) {
            playerHealth.TakeDamage(amount);
        }
    }
}
