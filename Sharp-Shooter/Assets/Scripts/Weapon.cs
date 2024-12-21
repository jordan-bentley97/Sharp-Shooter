using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField] GameObject hitVFXPrefab;
    [SerializeField] int damageAmount;
    [SerializeField] ParticleSystem muzzleflash;
    [SerializeField] Animator animator;

    StarterAssetsInputs starterAssetsInputs;

    const string SHOOT_STRING = "Shoot";

    void Awake() { 
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    void Update() {
        HandleShoot();
    }

    private void HandleShoot() {
        if (!starterAssetsInputs.shoot) return;

        muzzleflash.Play();
        animator.Play(SHOOT_STRING, 0, 0f);
        starterAssetsInputs.ShootInput(false);

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity)) {

            Instantiate(hitVFXPrefab, hit.point, Quaternion.identity);
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.takeDamage(damageAmount);

            
        }
    }
}
