using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    public float jumpforce;
    private Rigidbody2D mrigidbody2D;
    private static Vector2 fup = new Vector2(0.0f, 1.0f);
    private static Vector2 fr = new Vector2(1.0f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        mrigidbody2D = GetComponent<Rigidbody2D>();

    }
    private bool enable2jump = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)&&enable2jump)
        {
            Debug.Log("jump");
            mrigidbody2D.AddForce(fup * jumpforce, ForceMode2D.Impulse);
            enable2jump= false;
        }
        mrigidbody2D.AddForce(fr * (Convert.ToInt32(Input.GetKey(KeyCode.D)) - Convert.ToInt32(Input.GetKey(KeyCode.A))), ForceMode2D.Force);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("µÿ√Ê"))
        {
            Debug.Log("onhit");
            enable2jump= true;
        }
    }
}
