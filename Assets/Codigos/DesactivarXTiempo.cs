using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarXTiempo : MonoBehaviour
{
    //DESACTIVADOR
    public GameObject objADesactivar;
    public float tiempoDesactivado;
    public bool estaDesactivado = false;

    //Tags
    public string[] tagsPosibles = {"Tag1", "Tag2", "Tag3"};


    //ATRAER
    private bool isAttracted = false;
    private Vector2 attractionOrigin;
    public float mSpeed;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttracted)//
        {
            MoveToRay(attractionOrigin);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!estaDesactivado)
        {
            if (collision.gameObject.tag == "PlayerOne")
            {
                objADesactivar.SetActive(false);
                estaDesactivado = true;
                Audiomanager.PlaySound("Recojecaja");
                Invoke("ActivarObjetos", tiempoDesactivado);
            }

            if (collision.gameObject.tag == "PlayerTwo")
            {
                objADesactivar.SetActive(false);
                estaDesactivado = true;
                Audiomanager.PlaySound("Recojecaja");
                Invoke("ActivarObjetos", tiempoDesactivado);
            }


        }
    }

    public void ActivarObjetos()
    {
        int randomIndex = Random.Range(0, tagsPosibles.Length);
        objADesactivar.tag = tagsPosibles[randomIndex];

        objADesactivar.SetActive(true);
        estaDesactivado = false;
        Audiomanager.PlaySound("Aparececaja");
    }


    //ATRAER

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
