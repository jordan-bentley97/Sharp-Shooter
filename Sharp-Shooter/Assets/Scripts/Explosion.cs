using UnityEngine;

public class Explosion : MonoBehaviour {

    [SerializeField] float radius = 1.5f;

    void Start() {
        Explode();
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void Explode() {
        //dmg the player
    }

}
