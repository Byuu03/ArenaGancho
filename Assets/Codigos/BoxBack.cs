using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBack : MonoBehaviour
{
    //RETROCESO CAJA
    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    public bool KnockFromRight;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (KBCounter <= 0) //Aqui se debe de desactivar el movimiento
        {
            //_rigidbody.velocity = new Vector2(canMove * MovementSpeed, _rigidbody.velocity.y);
        }
        else
        {
            if (KnockFromRight == true)
            {
                rb.velocity = new Vector2(-KBForce, KBForce);
            }
            if (KnockFromRight == false)
            {
                rb.velocity = new Vector2(KBForce, KBForce);
            }

            KBCounter -= Time.deltaTime;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
