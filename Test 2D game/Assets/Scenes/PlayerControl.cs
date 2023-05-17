using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //动画组件
    private Animator ani;
    //刚体组件
    private Rigidbody2D rBody;
    // Start is called before the first frame update
    void Start()
    {
        //获取两个组件
        ani = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //获取水平轴
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        //按下左或右了
        if (horizontal != 0)
        {
            ani.SetFloat("Horizontal", horizontal);
            ani.SetFloat("Vertical", 0);
        }
        //按下上或下了
        if (vertical != 0)
        {
            ani.SetFloat("Horizontal", 0);
            ani.SetFloat("Vertical", vertical);
        }

        //切换跑步
        Vector2 dir = new Vector2(horizontal, vertical);//这是个向量
        ani.SetFloat("Speed",dir.magnitude);//返回向量长度

        //朝该方向移动
        rBody.velocity = dir * 0.5f;
    }
}
