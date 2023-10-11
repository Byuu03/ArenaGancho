using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTag : MonoBehaviour
{
    public string newTag;

    public PlayerMovement playerMove;

    public float mSpeed;

    //public float delayTime; //Gpt
    //private bool tagChange = false; //gpt

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerOne")
        {
            //StartCoroutine(ChangeTagWithDelay());
            gameObject.tag = newTag;
            //return;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerOne")
        {
            playerMove.KBCounter = playerMove.KBTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                playerMove.KnockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                playerMove.KnockFromRight = false;
            }
        }
    }

    public void MoveToRay(Vector2 origin) //Apenas se mueve hacia el origen del raycast
    {
        //transform.position = Vector2.MoveTowards(transform.position, origin.)
        Vector2 moveDirection = (origin - (Vector2)transform.position).normalized;
        Vector2 newpos = Vector2.MoveTowards((Vector2)transform.position, origin, mSpeed * Time.deltaTime);

        transform.position = newpos;

        //transform.Translate(moveDirection * mSpeed * Time.deltaTime); //APENAS SE MUEVE .gpt
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if ( tagChange || collision.gameObject.tag == "PlayerOne")
    //    {
    //        StartCoroutine(ChangeTagWithDelay());
    //        //gameObject.tag = newTag;
    //        return;
    //    }


    //}

    //IEnumerator ChangeTagWithDelay()
    //{
    //    yield return new WaitForSeconds(delayTime);
    //    gameObject.tag = newTag;
    //    tagChange = true;
    //}
}
