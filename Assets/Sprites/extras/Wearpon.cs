using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wearpon : MonoBehaviour
{
    public enum Modes
    {
        melee,
        Straight,
        Follow,
        Throw
    }

    public Sprite sprite;
    public GameObject projectile;
    public float missilSpeed;
    public float coolDown;
    //public Vector3 tip;
    public Modes missilModes;

    //AÑADIR LIMITE DE USOS A LAS ARMAS Y DESPUES QUE DESAPAREZCAN
}
