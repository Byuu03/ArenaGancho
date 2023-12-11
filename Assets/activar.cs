using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activar : MonoBehaviour
{
    public GameObject aActivar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        aActivar.SetActive(true);
    }
}
