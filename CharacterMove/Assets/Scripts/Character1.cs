using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character1 : MonoBehaviour
{
    Animator animator;
    Vector3 move;

    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Move(h, 0, v);
        UpdateAnim();
    }

    void Move( float x,float y,float z )
    {
        //World
        move = new Vector3(x, y, z);

        Vector3 to = transform.position + move;
        transform.LookAt(to);

        transform.position += move * speed * Time.deltaTime;
    }

    void UpdateAnim()
    {
        float forward = move.magnitude;
        animator.SetFloat("Forward", forward);
    }
}
