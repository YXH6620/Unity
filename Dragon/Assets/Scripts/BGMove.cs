using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    public float speed;
    Material mat;

    void Start()
    {
        mat = GetComponent<MeshRenderer>().sharedMaterial;//¹²Ïí²ÄÖÊ
    }

    
    void Update()
    {
        mat.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
    }
}
