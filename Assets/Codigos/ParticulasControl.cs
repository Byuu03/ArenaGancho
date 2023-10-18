using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulasControl : MonoBehaviour
{
    [SerializeField] ParticleSystem movementParticle;

    [Range(0, 10)]
    [SerializeField] int occurAfterVelocity;

    [Range(0, 0.2f)]
    [SerializeField] float dustFormationPeriod;

    float counter;

    [SerializeField] Rigidbody2D myRb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        counter += Time.deltaTime;

        if (Mathf.Abs(myRb.velocity.x) > occurAfterVelocity)
        {
            if (counter > dustFormationPeriod)
            {
                movementParticle.Play();
                counter = 0;
            }
        }
    }
}
