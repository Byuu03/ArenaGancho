using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorGiros : MonoBehaviour
{
    public GameObject objAActivar;
    public int contadores;
    public int cantidadLimite;
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
        if (collision.gameObject.tag == "Suelo")
        {
            contadores++;
        }

        if (contadores >= cantidadLimite)
        {
            objAActivar.SetActive(true);
            contadores = 0;
        }
    }
}
