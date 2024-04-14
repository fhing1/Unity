using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float playSpeed;//�������л��ֶΣ�ʹ�ñ�������ֱ����Unity�ϱ༭
    private float horizontal;
    private bool FaceRight = true;
    private Animator myAnim;
    [SerializeField] float JumpSpeed;
    private BoxCollider2D myFeet;
    private bool isGround;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//����2D��ɫ��ײ����
        myAnim = GetComponent<Animator>();//��ȡ��ɫ��Ϊ
        myFeet = GetComponent<BoxCollider2D>();//��ȡ��ɫ���Ƿ��ڵ���
    }

    void Update()
    {   //��ȡ���ˮƽ��������
        horizontal = Input.GetAxisRaw("Horizontal");
        //����ֵΪ-1,0,1,Ĭ�ϰ�������Ϊ-1������Ϊ1�����ƶ�Ϊ0
        Jump();//Update������֡��Ӱ�죬ÿ֡ˢ��ʱ������Ұ������룬����֡�ʵĸı���������
        //FixedUpdate��������֡��Ӱ�죬�̶�Ƶ�ʣ���Ϊ��Ծ��Ҫ������Ⲣ��Ӧ
        //���Թ̶�Ƶ�ʶ�����Ծ�ļ�ⲻ̫�Ѻá�
        CheckGround();
        SwithAction();
    }
    private void FixedUpdate()
    {
        Move();
        Run();
    }
    void CheckGround()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
        Debug.Log(isGround);
    }
    private void Move()
    {
        //�����ƶ�
        rb.velocity = new Vector2(horizontal * playSpeed, rb.velocity.y);
        //����y�᲻��,�������λ��

        if ((FaceRight && horizontal < 0) || (!FaceRight && horizontal > 0))
        {   //�жϽ�ɫת��,ֱ�ӷ�ת
            FaceRight = !FaceRight;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
    private void Run()
    {

        bool playerHasXAxisSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;//����ɫX����ٶ��Ƿ����0С��1
        myAnim.SetBool("IsRun", playerHasXAxisSpeed);//ͨ��ǰ����ж���IsRun��ֵ
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGround) {
                myAnim.SetBool("IsJump", true);
                Vector2 jumpV1 = new Vector2(0.0f, JumpSpeed);//������Ծ�ٶȳ�ʼ��Ϊ0
                rb.velocity = Vector2.up * jumpV1;//�Ѹ����ٶ����ó���Ծ�ٶ�����
            }
        }
    }
    private void SwithAction()
    {
        myAnim.SetBool("Idle", false);
        if (myAnim.GetBool("IsJump"))
        {
            if(rb.velocity.y < 0.0f)
            {
                myAnim.SetBool("IsJump", false);
                myAnim.SetBool("Idle", true);
            }
        }
    }
}
