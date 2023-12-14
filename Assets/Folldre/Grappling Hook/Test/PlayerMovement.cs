﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;
    public float JumpForce = 1;
    private Rigidbody2D _rigidbody;
    public bool derecha = true;

    bool Air = false;

    //public RotarGancho parentGancho;
    public GrapplingGun ganchame;

    //PUAS / KILL
    bool Pua = false;

    //Animacion
    public Animator animator;

    //PARALISIS
    public bool canMove;

    //LENTITUD
    public bool isSlow;

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

        isSlow = false;
        isTwist = false;

    }

    //CONTROLES
    private void Update()
    {

        if (canMove)
        {
            //animator.SetFloat("Speed", Mathf.Abs(MovementSpeed));
            if (Input.GetKey(izquierdaKey))
            {
                animator.SetFloat("Speed", Mathf.Abs(MovementSpeed));
                derecha = false;
                _rigidbody.velocity = new Vector2(-MovementSpeed, _rigidbody.velocity.y);
                transform.localRotation = Quaternion.Euler(0, -180, 0f);

                //Audiomanager.PlaySound("Moverse");

                //parentGancho.ResetearRotacionIzquierda();
            }
            else if (Input.GetKey(derechaKey))
            {
                derecha = true;
                animator.SetFloat("Speed", Mathf.Abs(MovementSpeed));
                _rigidbody.velocity = new Vector2(MovementSpeed, _rigidbody.velocity.y);
                transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

                //Audiomanager.PlaySound("Moverse");

                //parentGancho.ResetearRotacionDerecha();
            }

            if (Input.GetKeyDown(derechaKey))
            {
                Audiomanager.PlaySound("Direccion");
            }
            if (Input.GetKeyDown(izquierdaKey))
            {
                Audiomanager.PlaySound("Direccion");
            }

            if (Input.GetKeyUp(izquierdaKey))
            {
                animator.SetFloat("Speed", 0);
                //Audiomanager.PlaySound("Moverse");
                //Audiomanager.PlaySound("Direccion");
            }
            if (Input.GetKeyUp(derechaKey))
            {
                derecha = true;
                animator.SetFloat("Speed", 0);
                //Audiomanager.PlaySound("Moverse");
                //Audiomanager.PlaySound("Direccion");
                //_rigidbody.velocity = new Vector2(MovementSpeed, _rigidbody.velocity.y);
                //transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            }


            if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
            {
                //_rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                print("Querias ajajaja F por ti colega");
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

        if (isSlow)
        {
            MovementSpeed = 2f;
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

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            Air = true;
            animator.SetBool("inAir", true);

            //Audiomanager.PlaySound("Aterrizar");
        }

        if (collision.gameObject.tag == "Puas")
        {
            Pua = false;
            animator.SetBool("inPuas", false);
        }
    }


    //PARALISIS & TWIST
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            Air = false;
            animator.SetBool("inAir", false);

            Audiomanager.PlaySound("Aterrizar");
        }

        if (collision.gameObject.tag == "Pared")
        {
            ganchame.OffGrappleGun();
        }

        if (collision.gameObject.tag == "Puas")
        {
            Pua = true;
            Audiomanager.PlaySound("Colsionbala");
            Invoke("DesactivarReaccion", 0f); //
            animator.SetBool("inPuas", true);
            animator.SetBool("inAir", false);
        }

        if (collision.gameObject.tag == "ParalyzeBox")
        {
            Invoke("DesactivarMovimiento", 0f);

            Audiomanager.PlaySound("Paralisis");
            Destroy(collision.gameObject);
            //collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "InverseBox")
        {
            Invoke("DesactivarMovimientoAnormal", 0f);

            Audiomanager.PlaySound("Confuse");
            Destroy(collision.gameObject);
            //collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "SlowBox")
        {
            Invoke("DesactivarLentitud", 0f);

            Audiomanager.PlaySound("Slower");
            Destroy(collision.gameObject);
            //collision.gameObject.SetActive(false);
        }

      
    }

    //PARALISIS
    public void DesactivarMovimiento()
    {
        canMove = false;
        ganchame.OffGrappleGun();
        Audiomanager.PlaySound("Paralisis");
        Invoke("ActivarMovimiento", 3f);
        print("No me puedo Mover");
    }

    public void ActivarMovimiento()
    {
        canMove = true;
        print("Me puedo Mover");
    }

    //KILL / PUA
    public void DesactivarReaccion()
    {
        canMove = false;
        Invoke("ActivarReaccion", 0.5f);

        animator.SetBool("inPuas", true);
        animator.SetBool("inAir", false);
    }

    public void ActivarReaccion()
    {
        canMove = true;
        animator.SetBool("inPuas", false);
        //animator.SetFloat("Speed", 0);

    }


    //TWIST
    public void DesactivarMovimientoAnormal()
    {
        isTwist = true;
        Audiomanager.PlaySound("Confuse");
        Invoke("ActivarMovimientoAnormal", 4f);
        print("MOVIMIENTO ALTERADO");
    }

    public void ActivarMovimientoAnormal()
    {
        isTwist = false;
        print("Movimineto Normal");
    }

    //LENTITUD

    public void DesactivarLentitud()
    {
        isSlow = true;

        Audiomanager.PlaySound("Slower");
        Invoke("ActivarLentitud", 5f);
        print("LENTO");
    }

    public void ActivarLentitud()
    {
        isSlow = false;
        MovementSpeed = 4f;
        print("NORMAL VEL");
    }

}