using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    Slider slider;
    EnemyHealth enemyHealth;
    Image fillImage;
    float maxHealth;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Start()
    {
        fillImage = GetComponentInChildren<Image>();
        enemyHealth = GetComponentInParent<EnemyHealth>();
        SetMaxHealth(enemyHealth.startingHealth);
        maxHealth = enemyHealth.startingHealth;

    }

    public void SetHealth(int amount)
    {
        slider.value = amount;
        UpdateColor(amount);
    }

    void SetMaxHealth(int amount)
    {
        slider.maxValue = amount;
        slider.value = amount;
    }

    void UpdateColor(float amount) {
        float halfHealth = maxHealth / 2f;

        if (amount > halfHealth) {
            float t = (maxHealth - amount) / halfHealth;
            t = Mathf.Pow(t, 0.5f);
            fillImage.color = Color.Lerp(Color.green, Color.yellow, t);
        } else {
            float t = amount / halfHealth;
            t = Mathf.Pow(t, 2f); 
            fillImage.color = Color.Lerp(Color.red, Color.yellow, t);
        }
    }
}
