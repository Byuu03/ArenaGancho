using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaCambiar : MonoBehaviour
{
    //EN EL PLAYER PARENT

    public Transform weaponSlot;
    public GameObject activaWeapon;


    // Start is called before the first frame update
    void Start()
    {
        var weapon = Instantiate(activaWeapon, weaponSlot.transform.position, weaponSlot.transform.rotation);
        weapon.transform.parent = weaponSlot.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActualizarArma(GameObject newArma)
    {
        activaWeapon = newArma;
        var weapon = Instantiate(activaWeapon, weaponSlot.transform.position, weaponSlot.transform.rotation);
        weapon.transform.parent = weaponSlot.transform;

    }
}
