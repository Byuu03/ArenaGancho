using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoController : MonoBehaviour
{
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
        if (collision.gameObject.tag == "PlayerOne")
        {
            GameManager.manager.HurtP1();
            //FindObjectOfType<GameManager>().HurtP1();
            GameManager.manager.WinGame();
        }

        if (collision.gameObject.tag == "PlayerTwo")
        {
            GameManager.manager.HurtP2();
            //FindObjectOfType<GameManager>().HurtP2();

            GameManager.manager.WinPjTwo();
        }
    }

}
