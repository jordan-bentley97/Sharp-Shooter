using System.Collections;
using UnityEngine;

public class DestroyPeices : MonoBehaviour
{
    [SerializeField] float timer;

    void Start()
    {
        StartCoroutine(DestroyPrefabPeices());    
    }

    IEnumerator DestroyPrefabPeices()
    {
        yield return new WaitForSeconds(timer);
        Destroy(this.gameObject);
    }
}
