using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{

    float MoveX;
    float MoveY;
    float Speed;

    public float PlayerSpeed;           //움직임
    public float PlayerRunSpeed;
    public float PlayerMaxStamina;     //스테미나
    public float PlayerNowStamina;
    public float JumpPower;            //점프

    Rigidbody2D rb;
    Slider slider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        slider = GameObject.Find("StaminaSlider").GetComponent<Slider>();
    }


    void Update()
    {

        Move();
        Jump();
        Stamina();

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

    void Jump()                 //점프
    {

        if( Input.GetKeyDown( KeyCode.W ) )
        {
            rb.AddForce( Vector2.up * JumpPower, ForceMode2D.Impulse );
        }

    }

    void Stamina()                  //스테미나
    {
         
        if( Input.GetKey( KeyCode.LeftShift ) && PlayerNowStamina >= 0 && ( Input.GetKey( KeyCode.A ) || Input.GetKey( KeyCode.D ) ) )  //스테미나 조절
        {
            PlayerNowStamina -= 5 * Time.deltaTime;
        }
        else if( PlayerNowStamina <= PlayerMaxStamina)
        {
            PlayerNowStamina += 5 * Time.deltaTime;
        }
        else
        {
            PlayerNowStamina = PlayerMaxStamina;
        }

        slider.value = PlayerNowStamina / PlayerMaxStamina;     //스테미너 바

    }
}
