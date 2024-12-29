using UnityEngine;

public class LookSway : MonoBehaviour {
    [SerializeField] float swayMultiplier;
    [SerializeField] float swaySmoothing;

    void Update() {
        float mouseX = Input.GetAxisRaw("Mouse X") * swayMultiplier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * swayMultiplier;
        float mouseZ = Input.GetAxisRaw("Mouse X") * swayMultiplier;
        float strafe = Input.GetAxis("Horizontal") * swayMultiplier;

        Quaternion rotX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotY = Quaternion.AngleAxis(mouseX, Vector3.up);
        Quaternion rotZ = Quaternion.AngleAxis(mouseZ, Vector3.back);
        Quaternion rotStrafe = Quaternion.AngleAxis(strafe, Vector3.back);

        Quaternion targetRot = rotX * rotY * rotZ * rotStrafe;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRot, swaySmoothing * Time.deltaTime);
    }
}