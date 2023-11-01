using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public BoxBack boxBack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Box")
    //    {
    //        boxBack.KBCounter = boxBack.KBTotalTime;
    //        if (collision.transform.position.x <= transform.position.x)
    //        {
    //            boxBack.KnockFromRight = true;
    //        }
    //        if (collision.transform.position.x > transform.position.x)
    //        {
    //            boxBack.KnockFromRight = false;
    //        }
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            boxBack.KBCounter = boxBack.KBTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                boxBack.KnockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                boxBack.KnockFromRight = false;
            }
        }
    }
}
