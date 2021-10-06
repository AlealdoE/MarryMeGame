using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public Animator animation;
    bool Jump = false;
    public int movespeed;
    private float direction;
    private Vector3 facingRight;
    private Vector3 facingLeft;
    public Rigidbody2D rigid;
    public bool taNoChao;
    public Transform detectaChao;
    public LayerMask oQueEhChao;
    public int doubleJump =1 ;
    // Start is called before the first frame update
    void Start()
    {
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * -1;
        rigid = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        taNoChao = Physics2D.OverlapCircle(detectaChao.position,0.2f,oQueEhChao);
        if(Input.GetButtonDown("Jump") && taNoChao)
        {
            rigid.velocity = Vector2.up*12;
        }
        if(Input.GetButtonDown("Jump") && !taNoChao && doubleJump >0)
        {
            rigid.velocity = Vector2.up*12;
            doubleJump --;
        }
        if(taNoChao)
        {
            doubleJump = 1;
        }
        if(Input.GetAxis("Horizontal")!= 0)
        {
            animation.SetBool("Correndo",true);
        }
        else
        {
            animation.SetBool("Correndo",false);
        }
        direction = Input.GetAxis("Horizontal");
        rigid.velocity= new Vector2(direction*movespeed, rigid.velocity.y);
        if(direction >0)
        {
            //olhando para direita
            transform.localScale = facingRight;
        }
        if(direction<0)
        {
            //olhando para a esquerda
            transform.localScale = facingLeft;
        }

        
        /*if(Input.GetKey("right")){
            rb.AddForce(new Vector2(0.1f, 0),ForceMode2D.Impulse);
            animation.Play("PlayerRunning");

        }
         if(Input.GetKey("left")){
            rb.AddForce(new Vector2(-0.1f, 0),ForceMode2D.Impulse);

        }
        if(Input.GetKey("up")){
            if(Jump)
            {
                Jump=false;
                 rb.AddForce(new Vector2(0, 10f),ForceMode2D.Impulse);
            }
        }*/
        
    }

    //void OnCollisionEnter2D(Collision2D col){

        //Jump = true;

   // }
}
