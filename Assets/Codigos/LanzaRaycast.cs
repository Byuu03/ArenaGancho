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

    
    //private bool isAttracting = false; //
    //private Retroceder attractedObj;  //

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
                        changeTagScript.AttrackToRay(raycastOrigin);
                        //linrender.enabled = true;
                    }

                    //hit.collider.GetComponent<ChangeTag>().MoveToRay(raycastOrigin);
                }

                if (hit.collider.CompareTag("Box"))
                {
                    //attraobj = hit.collider. GetComponent<>
                    Retroceder retrocederscript = hit.collider.GetComponent<Retroceder>();
                    if (retrocederscript != null)
                    {
                        //linrender.enabled = true;
                        //retrocederscript.MoveToRay(raycastOrigin);
                        //linrender.enabled = false;
                        retrocederscript.AttrackToRay(raycastOrigin);
                        
                    }
                    else
                    {
                        //retrocederscript.StopAttrack();
                    }
                    linrender.enabled = false;
                }

            }
       

            if (hit)
            {
                linrender.enabled = true;
                linrender.SetPosition(0, firepoint.position);
                linrender.SetPosition(1, hit.point);
                //linrender.enabled = false;

            }
            else
            {
               
            }


            Debug.DrawRay(raycastOrigin, raycastDirection * rayDistance, Color.yellow);
        }
        if (Input.GetKeyUp(lanzaRay))
        {
      
            
            linrender.enabled = false;
        }

    }
}
