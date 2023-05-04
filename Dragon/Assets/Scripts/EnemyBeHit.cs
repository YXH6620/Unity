using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeHit : MonoBehaviour
{
    SpriteRenderer[] renders;

    public float redTime = 0.1f;
    public float changeColorTime;

    public float hp;

    public Transform prefabBoom;

    void setColor(Color color)
    {
        if (renders[0].color==color)
        {
            return;
        }

        foreach(var r in renders)
        {
            r.color = color;
        }
    }

    void Start()
    {
        renders = GetComponentsInChildren<SpriteRenderer>();    
    }
    private void Update()
    {
        if(Time.time > changeColorTime)
        {
            setColor(Color.white);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        setColor(Color.red);
        changeColorTime = Time.time + redTime;

        hp -= 1;
        if(hp<=0)
        {
            //ËÀÍö
            Destroy(gameObject);
            //ÌØÐ§
            Instantiate(prefabBoom, transform.position, Quaternion.identity);
        }
    }

}
