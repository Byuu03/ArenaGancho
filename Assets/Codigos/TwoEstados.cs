using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoEstados : MonoBehaviour
{
    public int colisionesNecesarias; // Cambia este valor al número de colisiones requeridas.
    public GameObject objetoAActivar;
    public float tiempoDeActivacion; // Cambia este valor al tiempo que deseas que el objeto esté activado.

    [SerializeField]private int colisionesActuales = 0;
    [SerializeField]private bool objetoActivado = false;
    private float tiempoPasado = 0.0f;

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ParalyzeBox") && !objetoActivado)
        {
            colisionesActuales++;

            if (colisionesActuales >= colisionesNecesarias)
            {
                objetoActivado = true;
                objetoAActivar.SetActive(true);
            }
        }
    }

    private void Update()
    {
        if (objetoActivado)
        {
            tiempoPasado += Time.deltaTime;

            if (tiempoPasado >= tiempoDeActivacion)
            {
                objetoActivado = false;
                objetoAActivar.SetActive(false);
                colisionesActuales = 0;
                tiempoPasado = 0.0f;
            }
        }
    }

}
