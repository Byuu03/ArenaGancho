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
          
            Vector2 raycastOrigin = firepoint.position;
            Vector2 raycastDirection = firepoint.right;

            RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, raycastDirection, rayDistance, hitLayers);

            if (hit.collider != null)
            {

               

                //Debug.Log("Raycast golpeo: " + hit.collider.name);

                if (hit.collider.CompareTag("SpecialBox"))
                {
                    ChangeTag changeTagScript = hit.collider.GetComponent<ChangeTag>();
                    if (changeTagScript != null)
                    {
                        changeTagScript.AttrackToRay(raycastOrigin);
                     
                    }

                    //hit.collider.GetComponent<ChangeTag>().MoveToRay(raycastOrigin);
                }

                if (hit.collider.CompareTag("Box"))
                {
                    //attraobj = hit.collider. GetComponent<>
                    Retroceder retrocederscript = hit.collider.GetComponent<Retroceder>();
                    if (retrocederscript != null)
                    {
                     
                        retrocederscript.AttrackToRay(raycastOrigin);
                        
                    }
                    else
                    {
                        
                    }
                    linrender.enabled = false;
                }

                if (hit.collider.CompareTag("InverseBox"))
                {
                    //attraobj = hit.collider. GetComponent<>
                    Retroceder retrocederscript = hit.collider.GetComponent<Retroceder>();
                    if (retrocederscript != null)
                    {

                        retrocederscript.AttrackToRay(raycastOrigin);

                    }
                    else
                    {

                    }
                    linrender.enabled = false;
                }

                if (hit.collider.CompareTag("ParalyzeBox"))
                {
                    //attraobj = hit.collider. GetComponent<>
                    Retroceder retrocederscript = hit.collider.GetComponent<Retroceder>();
                    if (retrocederscript != null)
                    {

                        retrocederscript.AttrackToRay(raycastOrigin);

                    }
                    else
                    {

                    }
                    linrender.enabled = false;
                }

                if (hit.collider.CompareTag("SlowBox"))
                {
                    //attraobj = hit.collider. GetComponent<>
                    Retroceder retrocederscript = hit.collider.GetComponent<Retroceder>();
                    if (retrocederscript != null)
                    {

                        retrocederscript.AttrackToRay(raycastOrigin);

                    }
                    else
                    {

                    }
                    linrender.enabled = false;
                }

            }
       

            if (hit)
            {
                linrender.enabled = true;
                linrender.SetPosition(0, firepoint.position);
                linrender.SetPosition(1, hit.point);
               

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
