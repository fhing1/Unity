using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float JumpSpeed;//�������л��ֶΣ�ʹ�ñ�������ֱ����Unity�ϱ༭
    [SerializeField] float playSpeed;
    [SerializeField] float DoubleJumpSpeed;
    private Rigidbody2D rb;
    private float horizontal;
    private bool FaceRight = true;
    private Animator myAnim;
    private BoxCollider2D myFeet;
    private bool isGround;
    private bool canDoubleJump;
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
        //Attack();
    }
    private void FixedUpdate()
    {
        Overturn();
        Walk();
    }
    void CheckGround()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
       
    }
    private void Overturn()
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
    private void Walk()
    {

        bool playerHasXAxisSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;//����ɫX����ٶ��Ƿ����0С��1
        myAnim.SetBool("IsWalk", playerHasXAxisSpeed);//ͨ��ǰ����ж���IsRun��ֵ
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGround) {
                myAnim.SetBool("IsJump", true);
                Vector2 jumpV1 = new Vector2(0.0f, JumpSpeed);//������Ծ�ٶȳ�ʼ��Ϊ0
                rb.velocity = Vector2.up * jumpV1;//�Ѹ����ٶ����ó���Ծ�ٶ�����
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    myAnim.SetBool("DoubleJump", true);
                    Vector2 doubleJumpVel = new Vector2(0.0f, DoubleJumpSpeed);
                    rb.velocity = Vector2.up * doubleJumpVel;
                    canDoubleJump = false;
                }
            }
        }
    }
    private void SwithAction()
    {
        myAnim.SetBool("Idle", false);
        if (myAnim.GetBool("IsJump"))
        {
            if(rb.velocity.y < 0.0f)//�жϽ�ɫ����y���ٶ��Ƿ�С��0
            {
                myAnim.SetBool("IsJump", false);
                myAnim.SetBool("IsFall", true);
            }
        }
        else if (isGround)
            {
                myAnim.SetBool("IsFall", false);
                myAnim.SetBool("Idle", true);
            }

        if (myAnim.GetBool("DoubleJump"))
        {
            if (rb.velocity.y < 0.0f)//�жϽ�ɫ����y���ٶ��Ƿ�С��0
            {
                myAnim.SetBool("DoubleJump", false);
                myAnim.SetBool("DoubleFall", true);
            }
        }
        else if (isGround)
        {
            myAnim.SetBool("DoubleFall", false);
            myAnim.SetBool("Idle", true);
        }

    }
    //private void Attack()
    //{
    //    if (Input.GetButtonDown("Attack")) {
    //        myAnim.SetTrigger("IsAttack");
    //    }
    //}
}