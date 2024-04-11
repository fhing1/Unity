using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float playSpeed;//�������л��ֶΣ�ʹ�ñ�������ֱ����Unity�ϱ༭
    private float horizontal;
    private bool FaceRight=true;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();//����2D��ɫ��ײ����
    }
 
    void Update()
    {   //��ȡ���ˮƽ��������
        horizontal = Input.GetAxisRaw("Horizontal");
        //����ֵΪ-1,0,1,Ĭ�ϰ�������Ϊ-1������Ϊ1�����ƶ�Ϊ0
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {   
        rb.velocity = new Vector2(horizontal * playSpeed, rb.velocity.y);
        //����y�᲻��,�������λ��

        if ((FaceRight&&horizontal<0)||(!FaceRight&&horizontal>0))
        {   //�жϽ�ɫת��,ֱ�ӷ�ת
            FaceRight = !FaceRight;
            transform.localScale=new Vector3(transform.localScale.x*-1,transform.localScale.y,transform.localScale.z);
        }
    }
}
