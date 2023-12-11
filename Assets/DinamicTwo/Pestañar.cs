using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pestañar : MonoBehaviour
{
    public GameObject plataforma;
    public float timer;
    public float tiempoMin;
    public float tiempoMax;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < 3)
        {
            plataforma.SetActive(false);
        }

        if (timer >= 3)
        {
            plataforma.SetActive(true);
        }

        if (timer >= 6)
        {
            plataforma.SetActive(false);
            //timer = 0;
            //plataforma.SetActive(true);
        }

        if (timer >= 9)
        {
            plataforma.SetActive(true);
            //timer = 0;
            //plataforma.SetActive(true);
        }

        if (timer >= 12)
        {
            plataforma.SetActive(true);
            timer = 0;
            //plataforma.SetActive(true);
        }
    }
}
