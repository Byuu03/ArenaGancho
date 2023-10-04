using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaparecer : MonoBehaviour
{
    public Vector2 startPos;
    //public Particle

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
    //    if (collision.CompareTag("Puas"))
    //    {
    //        Die();
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Puas")
        {
            Die();
        }
    }


    void Die()
    {
        Respawn();
        //StartCoroutine(Reaparcer(0.5f));
    }

    void Respawn()
    {
        transform.position = startPos;
    }

    //IEnumerator Reaparcer(float duration)
    //{
    //    yield return new WaitForSeconds(duration);
    //    transform.position = startPos;
    //}

}
