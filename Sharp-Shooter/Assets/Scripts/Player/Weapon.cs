using Cinemachine;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] LayerMask interactionLayers;
    [SerializeField] ParticleSystem bulletHole;

    CinemachineImpulseSource impulseSource;

    AudioSource audioSource;

    void Awake () {
        impulseSource = GetComponent<CinemachineImpulseSource>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Shoot(WeaponSO weaponSO) {
        
        muzzleFlash.Play();
        impulseSource.GenerateImpulse();
        audioSource.Play();
        
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, interactionLayers, QueryTriggerInteraction.Ignore)) {

            Quaternion normalizedRotation = Quaternion.LookRotation(hit.normal);
            Instantiate(weaponSO.HitVFXPrefab, hit.point, normalizedRotation);

            EnemyHealth enemyHealth = hit.collider.GetComponentInParent<EnemyHealth>(); //turret collider is on child GO and robot collider is on parent GO. GetComponentInParent searches its own components before checking parents.
            enemyHealth?.TakeDamage(weaponSO.Damage);

            Vector3 offsetPosition = hit.point + hit.normal * 0.001f; //stops z-fighting of particle and surface textures appearing at same depth

            if (!enemyHealth) {
                Instantiate(bulletHole, offsetPosition, normalizedRotation);
            }
            
            
        }
    }
}
