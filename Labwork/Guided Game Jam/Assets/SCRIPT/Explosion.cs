using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    IEnumerator ExplosionExpire()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ExplosionExpire());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
