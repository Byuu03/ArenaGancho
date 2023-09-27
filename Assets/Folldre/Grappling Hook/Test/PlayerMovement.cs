using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed = 2;
    public float JumpForce = 1;
    private Rigidbody2D _rigidbody;
    public bool derecha = true;
     
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
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
}