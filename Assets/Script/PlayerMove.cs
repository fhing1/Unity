using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float playSpeed;//创建序列化字段，使该变量可以直接在Unity上编辑
    private float horizontal;
    private bool FaceRight=true;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();//导入2D角色碰撞刚体
    }
 
    void Update()
    {   //获取玩家水平方向输入
        horizontal = Input.GetAxisRaw("Horizontal");
        //返回值为-1,0,1,默认按下向左为-1，向右为1，不移动为0
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {   
        rb.velocity = new Vector2(horizontal * playSpeed, rb.velocity.y);
        //保持y轴不变,更新玩家位置

        if ((FaceRight&&horizontal<0)||(!FaceRight&&horizontal>0))
        {   //判断角色转向,直接翻转
            FaceRight = !FaceRight;
            transform.localScale=new Vector3(transform.localScale.x*-1,transform.localScale.y,transform.localScale.z);
        }
    }
}
