using UnityEngine;
using StarterAssets;
using Cinemachine;

public class ActiveWeapon : MonoBehaviour {

    [SerializeField] WeaponSO startingWeapon;
    [SerializeField] WeaponSO CurrentWeaponSO;
    [SerializeField] CinemachineVirtualCamera playerFollowCamera;
    [SerializeField] GameObject zoomVignette;

    Animator animator;
    StarterAssetsInputs starterAssetsInputs;
    FirstPersonController firstPersonController;
    Weapon currentWeapon;

    float timeSinceLastShot = 0f;
    float defaultFOV;
    float defaultRotationSpeed;
    int currentAmmo;

    const string SHOOT_STRING = "Shoot";

    void Awake() { 
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        firstPersonController = GetComponentInParent<FirstPersonController>();
        animator = GetComponent<Animator>();
        defaultFOV = playerFollowCamera.m_Lens.FieldOfView;
        defaultRotationSpeed = firstPersonController.RotationSpeed;
    }

    void Start() {
        currentWeapon = GetComponentInChildren<Weapon>();
    }

    void Update() {
        HandleShoot();
        HandleZoom();
    }

    private void HandleShoot() {

        timeSinceLastShot += Time.deltaTime;
        
        if (!starterAssetsInputs.shoot) return;

        if (timeSinceLastShot >= CurrentWeaponSO.FireRate) {
            currentWeapon.Shoot(CurrentWeaponSO);
            animator.Play(SHOOT_STRING, 0, 0f);
            timeSinceLastShot = 0f;   
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

    }
}
