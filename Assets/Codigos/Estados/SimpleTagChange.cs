using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTagChange : MonoBehaviour
{
    public string newTag;
    public Sprite nuevoSprite;

    private SpriteRenderer spRender;
    public GameObject objExplosion;

    //RETROCESO
    public PlayerMovement playerOneMove;
    public PlayerTwoMovement playerTwoMove;

    public float mSpeed;

    //ATRACCION
    private bool isAttracted = false;
    private Vector2 attractionOrigin;

    // Start is called before the first frame update
    void Start()
    {
        spRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttracted)
        {
            MoveToRay(attractionOrigin);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerOne")
        {
            gameObject.tag = newTag;

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null && nuevoSprite != null)
            {
                spriteRenderer.sprite = nuevoSprite;
            }
        }

        if (collision.gameObject.tag == "PlayerTwo")
        {
            gameObject.tag = newTag;

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null && nuevoSprite != null)
            {
                spriteRenderer.sprite = nuevoSprite;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            Instantiate(objExplosion, transform.position, Quaternion.identity);

            Audiomanager.PlaySound("Colsionbala");
            StopAttrack();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Puas")
        {
            Instantiate(objExplosion, transform.position, Quaternion.identity);

            Audiomanager.PlaySound("Colsionbala");
            StopAttrack();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Pared")
        {
            Instantiate(objExplosion, transform.position, Quaternion.identity);

            Audiomanager.PlaySound("Colsionbala");
            StopAttrack();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Box")
        {
            Instantiate(objExplosion, transform.position, Quaternion.identity);

            Audiomanager.PlaySound("Colsionbala");
            StopAttrack();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "PlayerOne")
        {
            Instantiate(objExplosion, transform.position, Quaternion.identity);

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

        }

        if (collision.gameObject.tag == "PlayerTwo")
        {
            Instantiate(objExplosion, transform.position, Quaternion.identity);

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

        }

        //-------------BALASSS----------------

        if (collision.gameObject.tag == "Misil")
        {
            Instantiate(objExplosion, transform.position, Quaternion.identity);

            Audiomanager.PlaySound("Colsionbala");
            StopAttrack();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Arrow")
        {
            Instantiate(objExplosion, transform.position, Quaternion.identity);

            Audiomanager.PlaySound("Colsionbala");
            StopAttrack();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Bomba")
        {
            Instantiate(objExplosion, transform.position, Quaternion.identity);

            Audiomanager.PlaySound("Colsionbala");
            StopAttrack();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "InverseBox")
        {
            Instantiate(objExplosion, transform.position, Quaternion.identity);

            Audiomanager.PlaySound("Colsionbala");
            StopAttrack();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "ParalyzeBox")
        {
            Instantiate(objExplosion, transform.position, Quaternion.identity);

            Audiomanager.PlaySound("Colsionbala");
            StopAttrack();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "SlowBox")
        {
            Instantiate(objExplosion, transform.position, Quaternion.identity);

            Audiomanager.PlaySound("Colsionbala");
            StopAttrack();
            Destroy(gameObject);
        }



    }

    //ATRAER CAJA
    public void AttrackToRay(Vector2 origin)
    {
        isAttracted = true;
        attractionOrigin = origin;
    }

    public void StopAttrack()
    {
        //print("Soy la cajaSpecial y me detuve");
        isAttracted = false;
    }


    public void MoveToRay(Vector2 origin) //Apenas se mueve hacia el origen del raycast
    {
        print("Impacto raycast");


        transform.position = Vector3.Lerp(transform.position, origin, mSpeed); //No se mueve


    }

}
