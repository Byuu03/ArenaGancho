using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed = 2;
    public float JumpForce = 1;
    private Rigidbody2D _rigidbody;

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
            _rigidbody.velocity = new Vector2(-MovementSpeed, _rigidbody.velocity.y);
            transform.localScale = new Vector3(-0.1927739f, 0.1927739f, 0.1927739f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.velocity = new Vector2(MovementSpeed, _rigidbody.velocity.y);
            transform.localScale = new Vector3(0.1927739f, 0.1927739f, 0.1927739f);
        }



        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }
}