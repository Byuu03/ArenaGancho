using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivar : MonoBehaviour
{
    public GameObject Panel;
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
        if (timer >= tiempoMin)
        {
            Panel.SetActive(true);
        }

        if (timer >= tiempoMax)
        {
            Panel.SetActive(false);
            timer = 0;
        }

    }
}
