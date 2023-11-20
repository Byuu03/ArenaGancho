using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaparecer : MonoBehaviour
{
    public Vector2 startPos;
    //SpriteRenderer sprender;
    public ParticleController particleController;
    //public Rigidbody2D myRb;


    private void Awake()
    {
        //sprender = GetComponent<SpriteRenderer>();
        //myRb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Puas")
        {
            Die();
        }
    }


    void Die()
    {
        particleController.PlayParticle(ParticleController.Particles.die, transform.position);
        //Respawn();
        StartCoroutine(Reaparcer(0.5f));
    }

    //void Respawn()
    //{
    //    transform.position = startPos;
    //}

    //Timer para reaparecer

    IEnumerator Reaparcer(float duration)
    {
        //myRb.simulated = false;
        //myRb.velocity = new Vector2(0, 0);
        //sprender.enabled = false;
        yield return new WaitForSeconds(duration);
        transform.position = startPos;
        //sprender.enabled = true;
        //myRb.simulated = true;
    }

}
