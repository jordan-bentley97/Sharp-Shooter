using StarterAssets;
using UnityEngine;

public class LookSway : MonoBehaviour {
    [SerializeField] float swayMultiplier;
    [SerializeField] float swaySmoothing;

    StarterAssetsInputs starterAssetsInputs;

    void Awake() {
        starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
    }

    void Update() {
        float mouseX = starterAssetsInputs.look.x * swayMultiplier;
        float mouseY = starterAssetsInputs.look.y * swayMultiplier;
        float mouseZ = starterAssetsInputs.look.x * swayMultiplier;
        float strafe = starterAssetsInputs.move.x * 2 * swayMultiplier;

        Quaternion rotX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotY = Quaternion.AngleAxis(mouseX, Vector3.up);
        Quaternion rotZ = Quaternion.AngleAxis(mouseZ, Vector3.back);
        Quaternion strafeRot = Quaternion.AngleAxis(-strafe, Vector3.forward);

        Quaternion targetRot = rotX * rotY * rotZ * strafeRot;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRot, swaySmoothing * Time.deltaTime);
    }
}