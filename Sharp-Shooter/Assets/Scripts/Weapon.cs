using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField] int damageAmount;
    [SerializeField] ParticleSystem muzzleflash;

    StarterAssetsInputs starterAssetsInputs;

    void Awake() { 
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    void Update() {
        HandleShoot();
    }

    private void HandleShoot() {
        if (!starterAssetsInputs.shoot) return;

        muzzleflash.Play();

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity)) {

            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.takeDamage(damageAmount);

            starterAssetsInputs.ShootInput(false);
        }
    }
}
