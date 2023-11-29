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
        int randomIndex = Random.Range(0, tagsPosibles.Length);
        objADesactivar.tag = tagsPosibles[randomIndex];

        objADesactivar.SetActive(true);
        estaDesactivado = false;
    }


}
