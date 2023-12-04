using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayoDinamico : MonoBehaviour
{
    public Transform pointo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rayoHito();
    }

    void rayoHito()
    {
        RaycastHit2D hit = Physics2D.Raycast(pointo.position, transform.TransformDirection(Vector2.down), 10f);

        if (hit)
        {
            Debug.DrawRay(pointo.position, pointo.TransformDirection(Vector2.down) * 10f, Color.red);
            Debug.Log(hit.transform.name);
        }
    }
}
