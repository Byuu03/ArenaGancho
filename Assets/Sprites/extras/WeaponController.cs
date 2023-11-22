using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    //EN EL SLOT
    public Transform firePoint;
    public GameObject ammoType;

    public float shotSpeed;
    public float shotCounter, fireRate;

    [Header("Disparo")]
    public KeyCode shoott;

    public int maxShots;
    private int remainiShots;

    // Start is called before the first frame update
    void Start()
    {
        remainiShots = maxShots;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(shoott))
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = fireRate;
                Shooter();
            }
        }
        else
        {
            shotCounter = 0;
        }
    }

    public void Shooter()
    {
        if (remainiShots > 0)//
        {
            remainiShots--;//

            int playerDir()
            {
                if (transform.root.localRotation.y < 0)
                {
                    return -1;
                }
                else
                {
                    return +1;
                }
            }

            GameObject shot = Instantiate(ammoType, firePoint.position, firePoint.rotation);
            Rigidbody2D shotRB = shot.GetComponent<Rigidbody2D>();
            shotRB.AddForce(firePoint.right * shotSpeed * playerDir(), ForceMode2D.Impulse);

            maxShots--;

            Destroy(shot.gameObject, 1f);

            if (maxShots <= 0)
            {
                if (transform.parent != null)
                {
                    // Busca el componente PlayerWeaponController en el objeto raíz del jugador
                    Recursogpt playerController = transform.root.GetComponent<Recursogpt>();

                    if (playerController != null)
                    {
                        // Llama a la función WeaponOutOfAmmo en el script PlayerWeaponController
                        playerController.WeaponOutOfAmmo();
                    }
                }

                // Destruye el objeto del arma actual
                Destroy(gameObject);
            }
        }

    }

}
