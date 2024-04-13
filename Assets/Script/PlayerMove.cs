using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float playSpeed;//创建序列化字段，使该变量可以直接在Unity上编辑
    private float horizontal;
    private bool FaceRight=true;
    private Animator myAnim;
    [SerializeField] float JumpSpeed;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();//导入2D角色碰撞刚体
        myAnim=GetComponent<Animator>();//获取角色行为
    }
 
    void Update()
    {   //获取玩家水平方向输入
        horizontal = Input.GetAxisRaw("Horizontal");
        //返回值为-1,0,1,默认按下向左为-1，向右为1，不移动为0
        Jump();//Update函数受帧率影响，每帧刷新时捕获玩家按键输入，随着帧率的改变变快或变慢。
        //FixedUpdate函数则不受帧率影响，固定频率，因为跳跃需要立即检测并回应
        //所以固定频率对于跳跃的检测不太友好。
    }
    private void FixedUpdate()
    {
        Move();
        Run();
    }
    private void Move()
    {   
        //左右移动
        rb.velocity = new Vector2(horizontal * playSpeed, rb.velocity.y);
        //保持y轴不变,更新玩家位置

        if ((FaceRight&&horizontal<0)||(!FaceRight&&horizontal>0))
        {   //判断角色转向,直接翻转
            FaceRight = !FaceRight;
            transform.localScale=new Vector3(transform.localScale.x*-1,transform.localScale.y,transform.localScale.z);
        }
    }
    private void Run()
    {
        //RUN行为
        bool playerHasXAxisSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;//检测角色X轴的速度是否大于0小于1
        myAnim.SetBool("IsRun", playerHasXAxisSpeed);//通过前面的判定对IsRun赋值
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jumpV1 = new Vector2(0.0f, JumpSpeed);
            rb.velocity=Vector2.up*jumpV1;
        }
    }
}
