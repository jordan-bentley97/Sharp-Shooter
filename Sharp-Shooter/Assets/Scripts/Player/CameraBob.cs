using StarterAssets;
using UnityEngine;

public class CameraBob : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float walkingBobbingSpeed = 14f; 
    [SerializeField] float runningBobbingSpeed = 18f; 
    [SerializeField] float bobbingAmount = 0.05f;

    float defaultYPos;
    float timer; 
    FirstPersonController firstPersonController;
    StarterAssetsInputs starterAssetsInputs;

    void Start() {
        defaultYPos = transform.localPosition.y;
        firstPersonController = FindFirstObjectByType<FirstPersonController>();
        starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
    }

    void Update() {
        if (firstPersonController.Grounded && starterAssetsInputs.move != Vector2.zero) {

            float speed = starterAssetsInputs.sprint ? runningBobbingSpeed : walkingBobbingSpeed;

            timer += Time.deltaTime * speed;
            float newY = defaultYPos + Mathf.Sin(timer) * bobbingAmount;
            transform.localPosition = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);
        }
        else {
            timer = 0;
            transform.localPosition = new Vector3(transform.localPosition.x, defaultYPos, transform.localPosition.z);
        }
    }
}
