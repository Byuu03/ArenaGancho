using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{

    public float tiempoActivo;
    public float tiempoInactivo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CicloActivarDesactivar());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CicloActivarDesactivar()
    {
        while (true)
        {
            gameObject.SetActive(true);
            yield return new WaitForSeconds(tiempoActivo);


            gameObject.SetActive(false);
            yield return new WaitForSeconds(tiempoInactivo);
        }
    }
}
