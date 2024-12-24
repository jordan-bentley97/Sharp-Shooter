using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField] ParticleSystem muzzleFlash;

    public void Shoot(WeaponSO weaponSO) {
        
        muzzleFlash.Play();
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity)) {

            Instantiate(weaponSO.HitVFXPrefab, hit.point, Quaternion.identity);

            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.takeDamage(weaponSO.Damage);
        }
    }
}
