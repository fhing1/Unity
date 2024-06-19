using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage;
    [SerializeField] float Starttime;
    [SerializeField] float time;
    private Animator anim;
    private PolygonCollider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        coll=GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    void Attack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            coll.enabled = true;
            anim.SetTrigger("IsAttack");
            StartCoroutine(StartAttack());
           
        }
    }
    IEnumerator StartAttack() {
        yield return new WaitForSeconds(Starttime);
        coll.enabled = true;
        StartCoroutine(DisableHitBox());
    }
    IEnumerator DisableHitBox()
    {
        yield return new WaitForSeconds(time);
        coll.enabled = false;
    }
 }
