using UnityEngine;
using StarterAssets;
using Cinemachine;
using TMPro;

public class ActiveWeapon : MonoBehaviour {

    [SerializeField] WeaponSO startingWeapon;
    [SerializeField] CinemachineVirtualCamera playerFollowCamera;
    [SerializeField] GameObject zoomVignette;
    [SerializeField] TMP_Text ammoText;

    WeaponSO CurrentWeaponSO;
    Weapon currentWeapon;
    Animator animator;
    StarterAssetsInputs starterAssetsInputs;
    FirstPersonController firstPersonController;
    
    const string SHOOT_STRING = "Shoot";

    float timeSinceLastShot = 0f;
    float defaultFOV;
    float defaultRotationSpeed;
    int currentAmmo;

    void Awake() { 
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        firstPersonController = GetComponentInParent<FirstPersonController>();
        animator = GetComponent<Animator>();
        defaultFOV = playerFollowCamera.m_Lens.FieldOfView;
        defaultRotationSpeed = firstPersonController.RotationSpeed;
    }

    void Start() {
        SwitchWeapon(startingWeapon);
        AdjustAmmo(CurrentWeaponSO.MagazineSize);
    }

    void Update() {
        HandleShoot();
        HandleZoom();
    }

    public void AdjustAmmo(int amount) {
        currentAmmo += amount;

        if (currentAmmo > CurrentWeaponSO.MagazineSize) {
            currentAmmo = CurrentWeaponSO.MagazineSize;
        }
        ammoText.text = currentAmmo.ToString("D2"); //D@ = uses 2 digits always
    }

    private void HandleShoot() {

        timeSinceLastShot += Time.deltaTime;
        
        if (!starterAssetsInputs.shoot) return;

        if (timeSinceLastShot >= CurrentWeaponSO.FireRate && currentAmmo > 0) {
            currentWeapon.Shoot(CurrentWeaponSO);
            animator.Play(SHOOT_STRING, 0, 0f);
            timeSinceLastShot = 0f;
            AdjustAmmo(-1);
        }

        if (!CurrentWeaponSO.IsAutomatic) {
            starterAssetsInputs.ShootInput(false);
        }
    }

    void HandleZoom() {
        if (!CurrentWeaponSO.CanZoom) return;

        if (starterAssetsInputs.zoom) {
            playerFollowCamera.m_Lens.FieldOfView = CurrentWeaponSO.ZoomAmount;
            zoomVignette.SetActive(true);
            firstPersonController.ChangeRotationSpeed(CurrentWeaponSO.ZoomRotationSpeed);
        } else {
            playerFollowCamera.m_Lens.FieldOfView = defaultFOV;
            zoomVignette.SetActive(false);
            firstPersonController.ChangeRotationSpeed(defaultRotationSpeed);

        }
    }

    public void SwitchWeapon(WeaponSO weaponSO) {
        if (currentWeapon) {
            Destroy(currentWeapon.gameObject);
        }

        Weapon newWeapon = Instantiate(weaponSO.weaponPrefab, transform).GetComponent<Weapon>();
        currentWeapon = newWeapon;
        this.CurrentWeaponSO = weaponSO;

        AdjustAmmo(CurrentWeaponSO.MagazineSize);
    }
}
