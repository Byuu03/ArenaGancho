using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retroceder : MonoBehaviour
{
    public PlayerMovement playerOneMove;
    public PlayerTwoMovement playerTwoMove;

    public float mSpeed;

    private bool isAttracted = false;
    private Vector2 attractionOrigin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttracted)
        {
            MoveToRay(attractionOrigin);
        }
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
            StopAttrack();
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
            StopAttrack();
            //Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Suelo")
        {
            //StopAttrack();
            StopAttrackWithDelay(0.1f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            //StopAttrack();
        }
    }

    public void AttrackToRay(Vector2 origin)
    {
        isAttracted = true;
        attractionOrigin = origin;

        //transform.position = Vector3.Lerp(transform.position, origin, mSpeed);
    }

    public void StopAttrackWithDelay(float delay)
    {
        Invoke("StopAttrack", delay);
    }

    public void StopAttrack()
    {
        
        isAttracted = false;
    }

    public void MoveToRay(Vector2 origin) //Apenas se mueve hacia el origen del raycast
    {
        //print("Atraje caja");

        transform.position = Vector3.Lerp(transform.position, origin, mSpeed); //1

    }

}
