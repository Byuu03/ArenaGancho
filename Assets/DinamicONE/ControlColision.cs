using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlColision : MonoBehaviour
{
    public GameObject objADesactivar;
    public float tiempoDesactivado = 5f;
    public int colisionesNecesarias;

    private int contadorColisiones = 0;
    private bool segundoObjeActivo = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerOne")
        {
            contadorColisiones++;

            if (contadorColisiones >= colisionesNecesarias)
            {
                if (segundoObjeActivo)
                {
                    objADesactivar.SetActive(false);

                    Invoke("ActivarSegundoObjeto", tiempoDesactivado);

                    contadorColisiones = 0;
                }
            }
        }
    }

    private void ActivarSegundoObjeto()
    {
        objADesactivar.SetActive(true);
        segundoObjeActivo = true;
    }

}
