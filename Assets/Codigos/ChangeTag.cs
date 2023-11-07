using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTag : MonoBehaviour
{
    //CAMBIAR TAG Y SPRITE
    public string[] newTag = { "ParalyzeBox", "InverseBox", "SlowBox" };   //
    public Sprite[] tagSprites;

    //private string currentTag;
    //private Sprite currentSprite;

    private SpriteRenderer spRender;

    //RETROCESO
    public PlayerMovement playerOneMove;
    public PlayerMovement playerTwoMove;

    public float mSpeed;

    //ATRACCION
    private bool isAttracted = false;
    private Vector2 attractionOrigin;

    // Start is called before the first frame update
    void Start()
    {
        spRender = GetComponent<SpriteRenderer>();
        //SetRandomTagAndSprite();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttracted)
        {
            MoveToRay(attractionOrigin);
        }
    }

    //CAMBIAR TAG y SPRITE
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerOne" || collision.gameObject.tag == "PlayerTwo")
        {
            //gameObject.tag = currentTag;
            //spRender.sprite = currentSprite;

            // Luego, asignar un nuevo tag y sprite aleatorio
            //SetRandomTagAndSprite();

            int randomIndex = Random.Range(0, newTag.Length);
            gameObject.tag = newTag[randomIndex];

            if (randomIndex < tagSprites.Length)
            {
                spRender.sprite = tagSprites[randomIndex];
            }

            //SpriteRenderer spriterenderere = GetComponent<SpriteRenderer>();
            //if (spriterenderere != null && randomIndex < tagSprites.Length)
            //{
            //    spriterenderere.sprite = tagSprites[randomIndex];
            //}

        }

        //if (collision.gameObject.tag == "PlayerTwo")
        //{
        //    //gameObject.tag = newTag;

        //    int randomIndex = Random.Range(0, newTag.Length);
        //    gameObject.tag = newTag[randomIndex];

        //    if (randomIndex < tagSprites.Length)
        //    {
        //        spRender.sprite = tagSprites[randomIndex];
        //    }


        //    SpriteRenderer spriterenderere = GetComponent<SpriteRenderer>();
        //    if (spriterenderere != null && randomIndex < tagSprites.Length)
        //    {
        //        spriterenderere.sprite = tagSprites[randomIndex];
        //    }


        //}


        if (collision.gameObject.tag == "Suelo")
        {
            StopAttrack();
        }
    }

    //private void SetRandomTagAndSprite()
    //{
    //    int randomIndex = Random.Range(0, newTag.Length);
    //    currentTag = newTag[randomIndex];

    //    if (randomIndex < tagSprites.Length)
    //    {
    //        currentSprite = tagSprites[randomIndex];
    //        spRender.sprite = currentSprite;
    //    }
    //}


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
