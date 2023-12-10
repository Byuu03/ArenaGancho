using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giratorio : MonoBehaviour
{
    public float velocidad;
    [SerializeField] private int girosCompletos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, velocidad * Time.deltaTime);
        if (Mathf.Abs(transform.rotation.eulerAngles.z) >= 360 * 3)
        {
            transform.rotation = Quaternion.identity;

            //girosCompletos++;

            if (girosCompletos % 2 == 0)
            {
                velocidad = -Mathf.Abs(velocidad);
            }
            else
            {
                velocidad = Mathf.Abs(velocidad);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Techo")
        {
            girosCompletos++;
        }
    }

    public void RotarIzquierda()
    {
        // transform.Rotate(0f, 0f, -velocidad * Time.deltaTime);
        //girosCompletos++;
    }

    //public void RotarDerecha()
    //{
    //    transform.Rotate(0f, 0f, velocidad * Time.deltaTime);
    //}

}
