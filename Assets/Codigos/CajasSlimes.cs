using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajasSlimes : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerOne")
        {
            animator.SetBool("Colision", true);
        }

        if (collision.gameObject.tag == "PlayerTwo")
        {
            animator.SetBool("Colision", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerOne")
        {
            animator.SetBool("Colision", false);
        }

        if (collision.gameObject.tag == "PlayerTwo")
        {
            animator.SetBool("Colision", false);
        }
    }

}
