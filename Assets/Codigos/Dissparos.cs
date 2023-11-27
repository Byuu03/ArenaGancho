using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissparos : MonoBehaviour
{
    public GameObject balas;
    public Transform shotPoint;
    public float bulletForce;

    public float fireRate;
    float nextFire;

    public int maxShots;
    int shotsFire;

    [Header ("Boton")]
    public KeyCode bang;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(bang))
        {
            Shoot();
        }
        
    }

    public void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            GameObject bullet = Instantiate(balas, shotPoint.position, shotPoint.rotation) as GameObject;
            bullet.GetComponent<Rigidbody2D>().AddForce(shotPoint.right * bulletForce, ForceMode2D.Impulse);

            shotsFire++;

            if (shotsFire == maxShots)
            {
                gameObject.SetActive(false);
                //print("Se acabaron los disparos");

                Invoke("ResetShots", 0.2f);
            }

        }

       

    }

    void ResetShots()
    {
        shotsFire = 0;
    }

}
