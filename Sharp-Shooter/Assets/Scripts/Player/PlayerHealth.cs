using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [Range(1, 10)]
    [SerializeField] int startingHealth;
    [SerializeField] CinemachineVirtualCamera deathVirtualCamera;
    [SerializeField] Transform weaponCamera;
    [SerializeField] Transform UICamera;
    [SerializeField] Image[] shieldBars;
    [SerializeField] GameObject gameOverContainer;

    int currentHealth;
    int gameOverVirtualCameraPriority = 20;
    AudioSource[] audioSources;

    void Awake() {
        currentHealth = startingHealth;
        AdjustShieldUI();
        audioSources = GetComponents<AudioSource>();
    }

    public void TakeDamage(int amount){
        currentHealth -= amount;
        AdjustShieldUI();
        audioSources[1].Play();

        if (currentHealth <= 0) {
            Death();
        }
    }

    void Death() {
        weaponCamera.parent = null;
        UICamera.parent = null;
        deathVirtualCamera.Priority = gameOverVirtualCameraPriority;
        gameOverContainer.SetActive(true);
        StarterAssetsInputs starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
        starterAssetsInputs.SetCursorState(false);
        Destroy(this.gameObject);
    }

    void AdjustShieldUI() {
        for (int i = 0; i < shieldBars.Length; i++) {
            if (i < currentHealth) {
                shieldBars[i].gameObject.SetActive(true);
            } else {
                shieldBars[i].gameObject.SetActive(false);
            }
        }
    }
}
