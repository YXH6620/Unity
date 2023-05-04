using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayDestory : MonoBehaviour
{
    public float time = 0.05f;

    void Start()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }
    
    void Update()
    {
        
    }
}
