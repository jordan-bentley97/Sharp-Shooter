using System.Collections;
using UnityEngine;

public class DestroyPeices : MonoBehaviour
{
    [SerializeField] float timer;
    [SerializeField] float explosionForce;
    [SerializeField] float explosionRadius;
    [SerializeField] float upwardsModifier;

    void Start()
    {
        StartCoroutine(DestroyPrefabPeices());
        Explode();
    }

    IEnumerator DestroyPrefabPeices()
    {
        yield return new WaitForSeconds(timer);
        Destroy(this.gameObject);
    }

    void Explode()
    {
        Rigidbody[] childRigidBodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in childRigidBodies)
        {
            rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, upwardsModifier, ForceMode.Impulse);
        }
    }
}
