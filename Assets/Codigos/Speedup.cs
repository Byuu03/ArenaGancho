using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedup : MonoBehaviour
{
    //public float increase = 4f;
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
        //if (collision.tag == "Player")
        //{
        //    Audiomanager.PlaySound("Power up");
        //    GameObject player = collision.gameObject;
        //    playermove playerScript = player.GetComponent<playermove>();

        //    if (playerScript)
        //    {
        //        float oldSpeed = playerScript.speed;
        //        playerScript.speed += increase;
        //        playerScript.ChangeSpeed(oldSpeed, 2);
        //        Destroy(gameObject);
        //    }
        //}
    }


}
