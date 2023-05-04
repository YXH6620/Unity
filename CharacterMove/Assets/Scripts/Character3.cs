using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character3 : MonoBehaviour
{
    Animator animator;
    CharacterController controller;

    Vector3 move;
    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
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
        move = new Vector3(x, 0, z);
        //��һ֡�ƶ���������С��
        Vector3 m = move * speed * Time.deltaTime;

        transform.LookAt(transform.position + m);

        //ͨ��controller���ƶ�
        controller.Move(m);
    }

    void UpdateAnim()
    {
        animator.SetFloat("Forward ", controller.velocity.magnitude / speed);

    }
}
