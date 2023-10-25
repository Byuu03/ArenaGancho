using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToRaycast : MonoBehaviour
{
    public float mSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToRay(Vector2 origin) //Apenas se mueve hacia el origen del raycast
    {
        print("Impacto raycast caja corriente");

        //transform.position = Vector2.MoveTowards(transform.position, origin, 0.05f); //No se Movio

        transform.position = Vector3.Lerp(transform.position, origin, mSpeed); //No se mueve

        //Vector2 moveDirection = (origin - (Vector2)transform.position).normalized;
        //Vector2 newpos = Vector2.MoveTowards(transform.position, origin, mSpeed * Time.deltaTime);
        //transform.position = newpos;

        //transform.Translate(moveDirection * mSpeed * Time.deltaTime); //NO SE MUEVE .gpt

        //ULTIMA ACTUALIZACION: YA NO SE MUEVE
    }

}
