using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SueloCheck : MonoBehaviour
{
    [SerializeField] GameObject dustCloud;

    bool coroutineAllowed, grounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals ("Suelo"))
        {
            grounded = true;
            coroutineAllowed = true;
            Instantiate(dustCloud, transform.position, dustCloud.transform.rotation);
        }
    }



}
