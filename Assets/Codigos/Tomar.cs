using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomar : MonoBehaviour
{
    public bool grabbed;
    RaycastHit2D hit;
    public float distance = 2f;
    public Transform holdPoint;
    public float throwForce;
    public LayerMask notgrabbed;

    public PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!grabbed)
            {
                Physics2D.queriesStartInColliders = false;

                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);
                if (pm.derecha)
                {
                    hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);
                }
                else
                {
                    hit = Physics2D.Raycast(transform.position, -Vector2.right * transform.localScale.x, distance);
                }

                if (hit.collider != null && hit.collider.tag == "Box")
                {
                    grabbed = true;
                }

                //grab
            }
            else if(!Physics2D.OverlapPoint(holdPoint.position, notgrabbed))
            {
                grabbed = false;
                hit.collider.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() !=null)
                {
                    if (pm.derecha)
                    {
                        hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 0.2f) * throwForce;
                    }
                    else
                    {
                        hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, -0.2f) * -throwForce;
                    }
                    //hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 0.2f) * throwForce;
                }

                //throw
            }
        }

        if (grabbed)
        {
            hit.collider.gameObject.transform.position = holdPoint.position;
            hit.collider.gameObject.GetComponent<BoxCollider2D>().isTrigger=true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
    }

}
