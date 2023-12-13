using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarLayer : MonoBehaviour
{
    //public string nvoLayer = "Water";
    public GrapplingGun ganchoOne;
    //public GrapplingGun ganchoTwo;

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
            ganchoOne.OffGrappleGun();
            print("J1 CHOCOLA");
            //int newLayerIndex = LayerMask.NameToLayer(nvoLayer);
            //gameObject.layer = newLayerIndex;

            //gameObject.layer = LayerMask.LayerToName(nvoLayer);
        }

        if (collision.gameObject.tag == "PlayerTwo")
        {
            //ganchoTwo.OffGrappleGun();
           //rint("J2 CHOCO");

            //int newLayerIndex = LayerMask.NameToLayer(nvoLayer);
            //gameObject.layer = newLayerIndex;

            //gameObject.layer = LayerMask.LayerToName(nvoLayer);
        }
    }

}
