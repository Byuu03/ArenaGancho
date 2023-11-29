using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarXTiempo : MonoBehaviour
{
    //DESACTIVADOR
    public GameObject objADesactivar;
    public float tiempoDesactivado;
    public bool estaDesactivado = false;

    //Temporizador
    //public GameObject objetoAActivar;
    //public float timer;
    //public float tiempoMax;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("ActivarObjeto", tiempoDeEspera);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (!estaDesactivado && collision.gameObject.tag == "PlayerOne")
    //    {

    //        gameObject.SetActive(false);
    //        estaDesactivado = true;
    //        Invoke("ActivarObjetos", tiempoDesactivado);

         
    //    }


    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!estaDesactivado)
        {
            if (collision.gameObject.tag == "PlayerOne")
            {
                objADesactivar.SetActive(false);
                estaDesactivado = true;
                Invoke("ActivarObjetos", tiempoDesactivado);
            }

            if (collision.gameObject.tag == "PlayerTwo")
            {
                objADesactivar.SetActive(false);
                estaDesactivado = true;
                Invoke("ActivarObjetos", tiempoDesactivado);
            }


        }
    }

    public void ActivarObjetos()
    {
        objADesactivar.SetActive(true);
        estaDesactivado = false;
    }

    //void ActivarObjeto()
    //{
    //    if (objetoAActivar != null)
    //    {
    //        objetoAActivar.SetActive(true);
    //    }
    //}

}
