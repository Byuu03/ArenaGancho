using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarXTiempo : MonoBehaviour
{
    //public float tiempoDesactivado;
    //public bool estaDesactivado = false;

    //Temporizador
    public GameObject objetoAActivar;
    public float timer;
    public float tiempoMax;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("ActivarObjeto", tiempoDeEspera);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (!estaDesactivado)
        //{
        //    if (collision.gameObject.tag == "PlayerOne")
        //    {
        //        gameObject.SetActive(false);
        //        estaDesactivado = true;
        //        Invoke("ActivarObjetos", tiempoDesactivado);
        //    }
        //}

        if (collision.gameObject.tag == "PlayerOne")
        {
            timer -= Time.deltaTime;
            if (timer >= 0)
            {
                objetoAActivar.SetActive(true);
            }
        }
    }

    //public void ActivarObjetos()
    //{
    //    gameObject.SetActive(true);
    //    estaDesactivado = false;
    //}

    void ActivarObjeto()
    {
        if (objetoAActivar != null)
        {
            objetoAActivar.SetActive(true);
        }
    }

}
