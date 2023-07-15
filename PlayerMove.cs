using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    float MoveX;
    float MoveY;
    float Speed;

    public float PlayerSpeed;
    public float PlayerRunSpeed;
    public float JumpPower;

    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

        Move();
        Jump(); 

    }

    void Move()
    {
         
        if( Input.GetKey( KeyCode.LeftShift) )          //속도조절(달리기)
        {
            Speed = PlayerRunSpeed;
        }
        else
        {
            Speed = PlayerSpeed;
        }

        MoveX = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;

        transform.position = new Vector2( transform.position.x + MoveX, transform.position.y + MoveY );

    }

    void Jump()
    {

        if( Input.GetKeyDown( KeyCode.W ) )
        {
            rb.AddForce( Vector2.up * JumpPower, ForceMode2D.Impulse );
        }

    }
}
