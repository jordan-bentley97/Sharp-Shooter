using Cinemachine;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField] ParticleSystem muzzleFlashVFX;
    [SerializeField] LayerMask interactionLayers;
    [SerializeField] ParticleSystem bulletHoleVFX;

    CinemachineImpulseSource impulseSource;

    AudioSource audioSource;

    void Awake () {
        impulseSource = GetComponent<CinemachineImpulseSource>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Shoot(WeaponSO weaponSO) {
        
        muzzleFlashVFX.Play();
        impulseSource.GenerateImpulse();
        audioSource.pitch = Random.Range(0.7f, 1.3f);
        audioSource.Play();
        
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, interactionLayers, QueryTriggerInteraction.Ignore))
        {

            Quaternion normalizedRotation = Quaternion.LookRotation(hit.normal);
            Instantiate(weaponSO.HitVFXPrefab, hit.point, normalizedRotation);

            EnemyHealth enemyHealth = hit.collider.GetComponentInParent<EnemyHealth>(); //turret collider is on child GO and robot collider is on parent GO. GetComponentInParent searches its own components before checking parents.
            enemyHealth?.TakeDamage(weaponSO.Damage);

            DestroyableObject destroyableObject = hit.collider.gameObject.GetComponent<DestroyableObject>();
            destroyableObject?.TakeDamage(weaponSO.Damage);

            ExplodingBarrel explodingBarrel = hit.collider.gameObject.GetComponent<ExplodingBarrel>();
            explodingBarrel?.TakeDamage(weaponSO.Damage);

            if (!enemyHealth)
            {
                Vector3 offsetPosition = hit.point + hit.normal * 0.001f; //stops z-fighting
                ParticleSystem bulletHole = Instantiate(bulletHoleVFX, offsetPosition, normalizedRotation);
                bulletHole.transform.SetParent(hit.transform, worldPositionStays: true);
            }

        }
    }
}