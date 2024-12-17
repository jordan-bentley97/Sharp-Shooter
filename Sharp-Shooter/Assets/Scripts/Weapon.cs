using UnityEngine;

public class Weapon : MonoBehaviour {
    void Start() {
        
    }

    void Update() {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity)) {
          Debug.Log(hit.collider.name);  
        }


            

            
    }
}
