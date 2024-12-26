using UnityEngine;

public class WeaponPickup : Pickup {

    [SerializeField] WeaponSO weaponSO;

    protected override void OnPickup(ActiveWeapon activeWeapon) {
        activeWeapon.SwitchWeapon(weaponSO);
    }

    // protected = It means the function is accessible to the class itself and its derived classes, but not to other parts of the program.

    //override = This keyword ensures the function is overriding a virtual function in a base class
}
