using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetrocederSimple : MonoBehaviour
{
    public PlayerMovement playerOneMove;
    public PlayerTwoMovement playerTwoMove;



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
            
            Destroy(gameObject);
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
           
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Suelo")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Pared")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Box")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "SpecialBox")
        {
            Destroy(gameObject);
        }

    }
}
