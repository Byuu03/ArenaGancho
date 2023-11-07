using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadosColision : MonoBehaviour
{
    //PARALYZE
    //[Header("PARALISIS")]   
    public GameObject impactParalisis;
    public float timerParalisis;

    //CONFUSION
    //[Header("CONFUSION")]
    public GameObject impactConfusion;
    public float timerConfusion;

    //LENTO
    //[Header("LENTITUD")]
    public GameObject impactLento;
    public float timerLento;

    // Start is called before the first frame update
    void Start()
    {
        impactParalisis.SetActive(false);
        impactConfusion.SetActive(false);

        impactLento.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //PARALISIS
        if (collision.gameObject.tag == "ParalyzeBox")
        {
            impactParalisis.SetActive(true);
            Invoke("DesactivarParalisisSprite", timerParalisis);
        }

        //CONFUSION
        if (collision.gameObject.tag == "InverseBox")
        {
            impactConfusion.SetActive(true);
            Invoke("DesactivarConfusionSprite", timerConfusion);
        }

        //LENTO
        if (collision.gameObject.tag == "SlowBox")
        {
            impactLento.SetActive(true);
            Invoke("DesactivarLentitudSprite", timerLento);
        }

    }

    //PARALYZE
    private void DesactivarParalisisSprite()
    {
        impactParalisis.SetActive(false);
    }

    //CONFUSION
    private void DesactivarConfusionSprite()
    {
        impactConfusion.SetActive(false);
    }

    //LENTO
    private void DesactivarLentitudSprite()
    {
        impactLento.SetActive(false);
    }

}
