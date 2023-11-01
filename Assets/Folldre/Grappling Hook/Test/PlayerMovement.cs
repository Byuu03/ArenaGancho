using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;
    public float JumpForce = 1;
    private Rigidbody2D _rigidbody;
    public bool derecha = true;

    //PARALISIS
    public bool canMove;

    //MOVIMIENTOS
    [Header("Keybinds")]
    public KeyCode derechaKey;
    public KeyCode izquierdaKey;

    //INVERTIR Controles
    public bool isTwist;

    [Header("KeyTwist")]
    public KeyCode nuevaDerechaKey;
    public KeyCode nuevaIzquierdaKey;

    //RETROCESO
    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    public bool KnockFromRight;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        canMove = true;

        isTwist = false;

    }

    //CONTROLES
    private void Update()
    {

        if (canMove)
        {
            if (Input.GetKey(izquierdaKey))
            {
                derecha = false;
                _rigidbody.velocity = new Vector2(-MovementSpeed, _rigidbody.velocity.y);
                transform.localRotation = Quaternion.Euler(0, -180, 0f);
            }
            else if (Input.GetKey(derechaKey))
            {
                derecha = true;
                _rigidbody.velocity = new Vector2(MovementSpeed, _rigidbody.velocity.y);
                transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            }



            if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
            {
                _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            }
        }

        if (isTwist)
        {
            if (Input.GetKey(nuevaIzquierdaKey))
            {
                derecha = false;
                _rigidbody.velocity = new Vector2(-MovementSpeed, _rigidbody.velocity.y);
                transform.localRotation = Quaternion.Euler(0, -180, 0f);
            }
            else if (Input.GetKey(nuevaDerechaKey))
            {
                derecha = true;
                _rigidbody.velocity = new Vector2(MovementSpeed, _rigidbody.velocity.y);
                transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
      

       
    }


    //RETROCESO
    private void FixedUpdate()
    {
        if (KBCounter <= 0) //Aqui se debe de desactivar el movimiento
        {
            //_rigidbody.velocity = new Vector2(canMove * MovementSpeed, _rigidbody.velocity.y);
        }
        else
        {
            if (KnockFromRight == true)
            {
                _rigidbody.velocity = new Vector2(-KBForce, KBForce);
            }
            if (KnockFromRight == false)
            {
                _rigidbody.velocity = new Vector2(KBForce, KBForce);
            }

            KBCounter -= Time.deltaTime;

        }
    }


    //PARALISIS & TWIST
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ParalyzeBox")
        {
            Invoke("DesactivarMovimiento", 0f);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "InverseBox")
        {
            Invoke("DesactivarMovimientoAnormal", 0f);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "SlowBox")
        {

        }
    }

    //PARALISIS
    public void DesactivarMovimiento()
    {
        canMove = false;
        Invoke("ActivarMovimiento", 3f);
        print("No me puedo Mover");
    }

    public void ActivarMovimiento()
    {
        canMove = true;
        print("Me puedo Mover");
    }

    //TWIST

    public void DesactivarMovimientoAnormal()
    {
        isTwist = true;
        Invoke("ActivarMovimientoAnormal", 4f);
        print("MOVIMIENTO ALTERADO");
    }

    public void ActivarMovimientoAnormal()
    {
        isTwist = false;
        print("Movimineto Normal");
    }

}