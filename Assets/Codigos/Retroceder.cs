using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retroceder : MonoBehaviour
{
    public PlayerMovement playerOneMove;
    public PlayerMovement playerTwoMove;

    public float mSpeed;

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
            playerOneMove.KBCounter = playerOneMove.KBTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                playerOneMove.KnockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                playerOneMove.KnockFromRight = false;
            }

            //Destroy(gameObject);
        }

        if (collision.gameObject.tag == "PlayerTwo")
        {
            playerTwoMove.KBCounter = playerTwoMove.KBTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                playerTwoMove.KnockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                playerTwoMove.KnockFromRight = false;
            }

            //Destroy(gameObject);
        }
    }

    public void MoveToRay(Vector2 origin) //Apenas se mueve hacia el origen del raycast
    {
        print("Atraje caja");
        transform.position = Vector3.Lerp(transform.position, origin, mSpeed);

        //transform.position = Vector2.MoveTowards(transform.position, origin.)
        //Vector2 moveDirection = (origin - (Vector2)transform.position).normalized;
        //Vector2 newpos = Vector2.MoveTowards((Vector2)transform.position, origin, mSpeed * Time.deltaTime);

        //transform.position = newpos;

        //transform.Translate(moveDirection * mSpeed * Time.deltaTime); //APENAS SE MUEVE .gpt
    }

}
