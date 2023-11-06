using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTag : MonoBehaviour
{
    public string[] newTag = { "ParalyzeBox", "InverseBox", "ShieldBox" };   //
    public Sprite[] tagSprites;

    public PlayerMovement playerOneMove;
    public PlayerMovement playerTwoMove;

    private SpriteRenderer spRender;

    public float mSpeed;

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

    //CAMBIAR TAG
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerOne")
        {
            //gameObject.tag = newTag;

            int randomIndex = Random.Range(0, newTag.Length);
            gameObject.tag = newTag[randomIndex];

            SpriteRenderer spriterenderere = GetComponent<SpriteRenderer>();
            if (spriterenderere != null && randomIndex < tagSprites.Length)
            {
                spriterenderere.sprite = tagSprites[randomIndex];
            }
            //spRender.color = Color.yellow;
            //Destroy(gameObject);
        }

        if (collision.gameObject.tag == "PlayerTwo")
        {
            //gameObject.tag = newTag;

            int randomIndex = Random.Range(0, newTag.Length);
            gameObject.tag = newTag[randomIndex];

            SpriteRenderer spriterenderere = GetComponent<SpriteRenderer>();
            if (spriterenderere != null && randomIndex < tagSprites.Length)
            {
                spriterenderere.sprite = tagSprites[randomIndex];
            }

            //spRender.color = Color.yellow;
            //Destroy(gameObject);
        }


        if (collision.gameObject.tag == "Suelo")
        {
            StopAttrack();
        }
    }


    //RETROCESO AL IMPACTAR
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



    //ATRAER CAJA
    public void AttrackToRay(Vector2 origin)
    {
        isAttracted = true;
        attractionOrigin = origin;
    }

    public void StopAttrack()
    {
        print("Soy la cajaSpecial y me detuve");
        isAttracted = false;
    }


    public void MoveToRay(Vector2 origin) //Apenas se mueve hacia el origen del raycast
    {
        print("Impacto raycast");


        transform.position = Vector3.Lerp(transform.position, origin, mSpeed); //No se mueve

       
    }

}
