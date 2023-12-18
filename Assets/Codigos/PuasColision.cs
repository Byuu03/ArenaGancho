using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuasColision : MonoBehaviour
{
    public int colisionesNecesarias;
    public GameObject objetoAActivar;
    public float tiempoDeActivacion;

    [SerializeField] private int colisionesActuales = 0;
    [SerializeField] private bool objetoActivado = false;
    private float tiempoPasado = 0.0f;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne") && !objetoActivado)
        {
            colisionesActuales++;

            if (colisionesActuales >= colisionesNecesarias)
            {
                collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;

                objetoActivado = true;
                objetoAActivar.SetActive(true);
                Audiomanager.PlaySound("Derribado");
            }
        }

        if (collision.gameObject.CompareTag("PlayerTwo") && !objetoActivado)
        {
            colisionesActuales++;

            if (colisionesActuales >= colisionesNecesarias)
            {
                objetoActivado = true;
                objetoAActivar.SetActive(true);
                Audiomanager.PlaySound("Derribado");
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
