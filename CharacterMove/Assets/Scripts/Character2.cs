using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2 : MonoBehaviour
{
    Animator animator;
    Rigidbody rigid;
    Vector3 move;

    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Move(h, 0, v);
        UpdateAnim();
    }

    void Move(float x, float y, float z)
    {
        //World
        move = new Vector3(x, y, z);

    }
    //刚体移动，再FixedUpdate写
    private void FixedUpdate()
    {
        //根据move，直接改变刚体速度
        Vector3 v= move * speed;
        v.y = rigid.velocity.y;
        rigid.velocity = v;

        //让刚体朝向目标
        Quaternion q = Quaternion.LookRotation(move);
        rigid.MoveRotation(q);
    }
    void UpdateAnim()
    {
        float forward = move.magnitude;
        animator.SetFloat("Forward", rigid.velocity.magnitude / speed);
    }
}
