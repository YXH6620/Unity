using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character3Fall : MonoBehaviour
{
    Animator animator;
    CharacterController controller;

    Vector3 move;
    public float speed = 3;
    [Range(0.0f, 1.0f)]
    public float testSpeed = 1;
    bool isGround = true;

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

    float vy = 0;
    void Move(float x, float y, float z)
    {
        //World
        move = new Vector3(x, 0, z);
        //这一帧移动的向量很小，
        Vector3 m = move * speed * Time.deltaTime;

        if(isGround)
        {
            vy = 0;
        }
        else
        {
            vy += Physics.gravity.y * Time.deltaTime;
        }
        //这一帧的小位移y = 速度vy * 这一帧的时间
        m.y = vy * Time.deltaTime;

        transform.LookAt(transform.position + m);

        //通过controller来移动
        controller.Move(m);
    }

    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position + new Vector3(0, 0.2f, 0), Vector3.down);

        RaycastHit hit;
        Color color = Color.white;

        isGround = false;
        if(Physics.Raycast(ray,out hit,0.35f))
        {
            color=Color.red;
            isGround = true;
        }
        Debug.DrawLine(transform.position + new Vector3(0, 0.2f, 0), transform.position - new Vector3(0, -0.15f, 0), color);
    }

    void UpdateAnim()
    {
        animator.SetFloat("Forward ", controller.velocity.magnitude / speed * testSpeed);

    }
}
