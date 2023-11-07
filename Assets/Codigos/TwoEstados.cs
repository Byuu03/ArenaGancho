using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoEstados : MonoBehaviour
{
    public GameObject paralisis;
    public float timerparalis;

    // Start is called before the first frame update
    void Start()
    {
        paralisis.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ParalyzeBox")
        {
            print("salio paralisis");
            paralisis.SetActive(true);
            Invoke("DesavtivarParalitico", timerparalis);

        }
    }

    private void DesavtivarParalitico()
    {
        paralisis.SetActive(false);
    }

}
