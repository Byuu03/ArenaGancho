using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzaRaycast : MonoBehaviour
{
    public LayerMask hitLayers;
    public float rayDistance;

    public Transform firepoint;

    [Header("Keybinds")]
    public KeyCode lanzaRay;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        // Lanzar raycast
        if (Input.GetKeyDown(lanzaRay))
        {
            Vector2 raycastOrigin = firepoint.position;
            Vector2 raycastDirection = firepoint.right;

            RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, raycastDirection, rayDistance, hitLayers);

            if (hit.collider != null)
            {
                Debug.Log("Raycast golpeo: " + hit.collider.name);

                if (hit.collider.CompareTag("SpecialBox"))
                {
                    ChangeTag changeTagScript = hit.collider.GetComponent<ChangeTag>();
                    if (changeTagScript != null)
                    {
                        changeTagScript.MoveToRay(raycastOrigin);
                    }

                    //hit.collider.GetComponent<ChangeTag>().MoveToRay(raycastOrigin);
                }
            }

            //if (hit.transform.gameObject.tag == "Box")
            //{
            //    hit.transform.GetComponent<SpriteRenderer>().color = Color.red;

            //}

            if (hit != null && hit.transform.gameObject.tag == "Box")
            {
                hit.transform.gameObject.SendMessage("MoveToRay", raycastOrigin);
                //SE MUEVE DE A POCO
            }

            //if (hit.collider.CompareTag("Box"))
            //{
            //    hit.collider.GetComponent<ChangeTag>().MoveToRay(raycastOrigin);
            //}

            Debug.DrawRay(raycastOrigin, raycastDirection * rayDistance, Color.yellow);
        }
    }
}
