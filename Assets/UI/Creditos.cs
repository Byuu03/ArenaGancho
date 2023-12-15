using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creditos : MonoBehaviour
{
    public GameObject creditos;

    // Start is called before the first frame update
    void Start()
    {
        creditos.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EncederCreditos()
    {
        if (creditos != null)
        {
            bool isActive = creditos.activeSelf;
            creditos.SetActive(!isActive);
        }
    }

}
