using UnityEngine;

public class WeaponPickup : MonoBehaviour {

    [SerializeField] WeaponSO weaponSO;

    const string PLAYER_STRING = "Player";

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag(PLAYER_STRING)) {
            ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
            activeWeapon.SwitchWeapon(weaponSO);
            Destroy(this.gameObject);
        }
    }
}
