using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarGancho : MonoBehaviour
{
    public float vel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(0f, 0f, vel * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(0f, 0f, -vel * Time.deltaTime);
        }
    }
}
