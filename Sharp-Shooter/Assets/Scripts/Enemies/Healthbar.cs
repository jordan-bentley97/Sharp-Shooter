using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {
    [SerializeField] Slider slider;
    EnemyHealth enemyHealth;

    void Start() {
        enemyHealth = GetComponentInParent<EnemyHealth>();
        SetMaxHealth(enemyHealth.startingHealth);
    }

    public void SetHealth(int amount){
        slider.value = amount;
    }

    void SetMaxHealth(int amount){
        slider.maxValue = amount;
        slider.value = amount;
    }

}
