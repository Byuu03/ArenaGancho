using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WearponManager : MonoBehaviour
{
    public GameObject activeWeapon;
    Wearpon wpn;
    bool canShoot = true;

    public int totalShoots;

    [Header("ShootBoton")]
    public KeyCode ShotKey;

    // Start is called before the first frame update
    void Start()
    {
        wpn = activeWeapon.GetComponent<Wearpon>();

        GetComponent<SpriteRenderer>().sprite = wpn.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(ShotKey) && canShoot)
        {
            canShoot = false;
            StartCoroutine("CoolDown");

            Vector3 rotation = transform.parent.localScale.x == 1 ? Vector3.zero : Vector3.forward * 180; //MIRAR PLAYERMOVEMENT ROTATION
            GameObject projectile = Instantiate(wpn.projectile, transform.position + activeWeapon.transform.GetChild(0).localPosition * transform.parent.localScale.x, Quaternion.Euler(rotation));

            totalShoots--;

            if (wpn.missilModes == Wearpon.Modes.Straight)
            {
                projectile.GetComponent<Rigidbody2D>().velocity = transform.parent.localScale.x * Vector2.right * wpn.missilSpeed;
            }
            else if (wpn.missilModes == Wearpon.Modes.Throw)
            {
                projectile.GetComponent<Rigidbody2D>().isKinematic = false;

                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.parent.localScale.x, 1) * wpn.missilSpeed;
            }


        }

        if (totalShoots <= 0)
        {
            activeWeapon = null;
        }

    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(wpn.coolDown);
        canShoot = true;
    }

    public void UpdateWeapon(GameObject newWeapon)
    {
        activeWeapon = newWeapon;
        wpn = activeWeapon.GetComponent<Wearpon>();
        GetComponent<SpriteRenderer>().sprite = wpn.sprite;
    }

}
