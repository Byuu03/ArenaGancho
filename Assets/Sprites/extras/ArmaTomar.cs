using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaTomar : MonoBehaviour
{
    public GameObject weaponToGive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerOne")
        {
            collision.gameObject.GetComponent<ArmaCambiar>().ActualizarArma(weaponToGive);
            Destroy(GameObject.FindGameObjectWithTag("Weapon"));
            Destroy(gameObject);
        }
    }

}
