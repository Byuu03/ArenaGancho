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

    public LineRenderer linrender;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        linrender.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        // Lanzar raycast
        if (Input.GetKeyDown(lanzaRay))
        {
            //linrender.SetPosition(0, firepoint.position);
            Vector2 raycastOrigin = firepoint.position;
            Vector2 raycastDirection = firepoint.right;

            RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, raycastDirection, rayDistance, hitLayers);

            if (hit.collider != null)
            {

                //linrender.SetPosition(1, hit.point);

                Debug.Log("Raycast golpeo: " + hit.collider.name);

                if (hit.collider.CompareTag("SpecialBox"))
                {
                    ChangeTag changeTagScript = hit.collider.GetComponent<ChangeTag>();
                    if (changeTagScript != null)
                    {
                        changeTagScript.MoveToRay(raycastOrigin);
                        //linrender.enabled = true;
                    }

                    //hit.collider.GetComponent<ChangeTag>().MoveToRay(raycastOrigin);
                }

                if (hit.collider.CompareTag("Box"))
                {
                    Retroceder retrocederscript = hit.collider.GetComponent<Retroceder>();
                    if (retrocederscript != null)
                    {
                        //linrender.enabled = true;
                        retrocederscript.MoveToRay(raycastOrigin);
                        //linrender.enabled = false;
                    }
                }

            }
            //else
            //{
            //    linrender.SetPosition(1, raycastOrigin + ((Vector2)firepoint.transform.right * rayDistance));
            //}

            if (hit)
            {

                linrender.SetPosition(0, firepoint.position);
                linrender.SetPosition(1, hit.point);
                linrender.enabled = true;
            }
            else
            {
                //linrender.SetPosition(0, firepoint.position);
                //linrender.SetPosition(1, firepoint.position);
                //linrender.enabled = false;
            }


            Debug.DrawRay(raycastOrigin, raycastDirection * rayDistance, Color.yellow);
        }
        else if (Input.GetKeyUp(lanzaRay))
        {
            linrender.enabled = false;
        }

    }
}
