using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public float speed = 6;
    public Transform prefabExpl;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        //创建爆炸图
        if(prefabExpl)//不需要判空，判断变量指向物体，且物体（绝对）存在
        {
            Transform expl=Instantiate(prefabExpl,transform.position,Quaternion.identity);

        }
    }
}
