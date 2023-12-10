using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giratorio : MonoBehaviour
{
    public float velocidad;
    

    public GameObject objADesactivar;

    //public int giros;
    //private int girosNecesarios = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, velocidad * Time.deltaTime);

      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Techo")
        {
            
            objADesactivar.SetActive(false);
            velocidad = -velocidad;
            //giros++;
        }

       
    }


}
