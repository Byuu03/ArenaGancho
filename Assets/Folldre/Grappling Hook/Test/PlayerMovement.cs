using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;
    public float JumpForce = 1;
    private Rigidbody2D _rigidbody;
    public bool derecha = true;

    //public bool canMove;

    //Paralisis
    //public bool isParalyzed;
    //public float paralyzedEffectTimer;
    //public float paralyzedStatusDuration;
    //public bool checkingParalyze;
    //public int paralyzeChance;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        //canMove = true;

        //isParalyzed = false;
        //checkingParalyze = false;
    }

    private void Update()
    {
        //var movement = Input.GetAxis("Horizontal");
        //transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (Input.GetKey(KeyCode.A))
        {
            derecha = false;
            _rigidbody.velocity = new Vector2(-MovementSpeed, _rigidbody.velocity.y);
            transform.localRotation = Quaternion.Euler(0, -180, 0f);
        }
        else if (Input.GetKey(KeyCode.D))
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

    //public void CheckStatusEffect()
    //{
    //    if (isParalyzed == true)
    //    {
    //        paralyzedEffectTimer -= Time.deltaTime;
    //        if (paralyzedEffectTimer <= 0f)
    //        {
    //            isParalyzed = false;
    //            paralyzedEffectTimer = paralyzedStatusDuration;
    //        }

    //        if (checkingParalyze == true)
    //        {
    //            return;
    //        }
    //        else
    //        {
    //            StartCoroutine("CheckParalyze");
    //        }
    //    }
    //}

    //IEnumerator CheckParalyze()
    //{
    //    checkingParalyze = true;
    //    if (Random.Range(0, 100) <= paralyzeChance)
    //    {
    //        Debug.Log("Paralizado");
    //        MovementSpeed = 0f;
    //        yield return new WaitForSeconds(2f);

            
    //    }
    //}

}