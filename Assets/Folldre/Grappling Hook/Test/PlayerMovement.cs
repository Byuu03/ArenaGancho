using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;
    public float JumpForce = 1;
    private Rigidbody2D _rigidbody;
    public bool derecha = true;

    public bool canMove;

    [Header("Keybinds")]
    public KeyCode derechaKey;
    public KeyCode izquierdaKey;

    //RETROCESO
    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    public bool KnockFromRight;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        canMove = true;

    }

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
      

       
    }

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ParalyzeBox")
        {
            Invoke("DesactivarMovimiento", 0f);
            
        }
    }

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


}