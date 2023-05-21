using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    Playercontorl py;
    Animator anim;
    Rigidbody2D rigi;

    float move;
    bool jump;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        py = GetComponent<Playercontorl>();
        anim = GetComponent<Animator>();
        rigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        float temp = move;

        move *= speed;
        jump = Input.GetButton("Jump");

        //¶¯»­²¿·Ö
        if (py.isGrounded)
        {
            anim.SetFloat("speed", Mathf.Abs(temp));
            anim.SetBool("jump_up", false);
            anim.SetBool("jump_down", false);
        }
        else 
        {
            Vector3 vel = rigi.velocity;
            if (vel.y > 0)
            {
                anim.SetBool("jump_up", true);
                anim.SetBool("jump_down", false);
            }
            else 
            {
                anim.SetBool("jump_up", false);
                anim.SetBool("jump_down", true);
            }
        }
    }

    private void FixedUpdate()
    {
        py.Move(move, jump);
    }
}
