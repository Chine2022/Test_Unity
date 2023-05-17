using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //�������
    private Animator ani;
    //�������
    private Rigidbody2D rBody;
    // Start is called before the first frame update
    void Start()
    {
        //��ȡ�������
        ani = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //��ȡˮƽ��
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        //�����������
        if (horizontal != 0)
        {
            ani.SetFloat("Horizontal", horizontal);
            ani.SetFloat("Vertical", 0);
        }
        //�����ϻ�����
        if (vertical != 0)
        {
            ani.SetFloat("Horizontal", 0);
            ani.SetFloat("Vertical", vertical);
        }

        //�л��ܲ�
        Vector2 dir = new Vector2(horizontal, vertical);//���Ǹ�����
        ani.SetFloat("Speed",dir.magnitude);//������������

        //���÷����ƶ�
        rBody.velocity = dir * 0.5f;
    }
}
