using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarLayer : MonoBehaviour
{
    public string nvoLayer = "Water";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerOne")
        {
            int newLayerIndex = LayerMask.NameToLayer(nvoLayer);
            gameObject.layer = newLayerIndex;

            //gameObject.layer = LayerMask.LayerToName(nvoLayer);
        }
    }

}
