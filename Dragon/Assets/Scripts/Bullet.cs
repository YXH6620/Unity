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
        //������ըͼ
        if(prefabExpl)//����Ҫ�пգ��жϱ���ָ�����壬�����壨���ԣ�����
        {
            Transform expl=Instantiate(prefabExpl,transform.position,Quaternion.identity);

        }
    }
}
