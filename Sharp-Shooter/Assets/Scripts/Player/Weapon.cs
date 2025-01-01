using Cinemachine;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] LayerMask interactionLayers;

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

            Instantiate(weaponSO.HitVFXPrefab, hit.point, Quaternion.identity);

            EnemyHealth enemyHealth = hit.collider.GetComponentInParent<EnemyHealth>(); 
            enemyHealth?.takeDamage(weaponSO.Damage);
            
            //turret collider is on child GO and robot collider is on parent GO. GetComponentInParent searches its own components before checking parents.
        }
    }
}
