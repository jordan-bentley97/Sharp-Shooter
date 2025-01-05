using UnityEngine;

public abstract class Pickup : MonoBehaviour {

    [SerializeField] float rotationSpeed = 100f;

    AudioSource audioSource;

    const string PLAYER_STRING = "Player";

    void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag(PLAYER_STRING)) {
            
            this.GetComponent<Collider>().enabled = false;

            ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
            OnPickup(activeWeapon);
            audioSource.Play();
            Destroy(gameObject, audioSource.clip.length);
        }
    }

    void Update() {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    protected abstract void OnPickup(ActiveWeapon activeWeapon);
}
