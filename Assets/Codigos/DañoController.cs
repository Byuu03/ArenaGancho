using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoController : MonoBehaviour
{
    public int daño;
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
            
            GameManager.manager.HurtP1(daño);

            CinemachineMovimientoCamara.Instance.MoverCamara(2, 2, 0.2f);

            //FindObjectOfType<GameManager>().HurtP1();
            //CineMachineMovimientoCamara.Instance.MoverCamara(2, 2, 0.2f);
            //GameManager.manager.WinGame();
        }

        if (collision.gameObject.tag == "PlayerTwo")
        {
            GameManager.manager.HurtP2();

            CinemachineMovimientoCamara.Instance.MoverCamara(2, 2, 0.2f);

            //FindObjectOfType<GameManager>().HurtP2();
            //CineMachineMovimientoCamara.Instance.MoverCamara(5, 5, 0.5f);
            //GameManager.manager.WinPjTwo();
        }
    }

}
