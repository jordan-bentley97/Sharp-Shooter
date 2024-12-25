using UnityEngine;

public abstract class Pickup : MonoBehaviour {

    [SerializeField] float rotationSpeed = 100f;

    const string PLAYER_STRING = "Player";

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag(PLAYER_STRING)) {
            ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
            OnPickup(activeWeapon);
            Destroy(this.gameObject);
        }
    }

    void Update() {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    protected abstract void OnPickup(ActiveWeapon activeWeapon);
}
