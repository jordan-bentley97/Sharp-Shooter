using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class AdjustSensitivity : MonoBehaviour {

    [SerializeField] Slider sensitivitySlider;

    FirstPersonController firstPersonController;

    void Awake() {
        firstPersonController = FindFirstObjectByType<FirstPersonController>();
        sensitivitySlider.value = firstPersonController.RotationSpeed;
    }

    public void AdjustSens() {
        if (firstPersonController && sensitivitySlider) { 
            firstPersonController.RotationSpeed = sensitivitySlider.value;
        }
    }
}