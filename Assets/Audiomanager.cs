using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    //JUGADORES
    public static AudioClip DireccionSound;
    public static AudioClip AterrizarSound;
    public static AudioClip GanchoSound;
    public static AudioClip SoltarganchoSound;
    public static AudioClip ColisionbalaSound;
    public static AudioClip DerribadoSound;

    //CAJAS
    public static AudioClip AparecercajaSound;
    public static AudioClip RecojecajaSound;
    ////public static AudioClip PandaCorreSound;
    ////public static AudioClip PowerupSound;

    static AudioSource audioScr;
    //// Start is called before the first frame update
    void Start()
    {
        //JUGADORES
        DireccionSound = Resources.Load<AudioClip>("Direccion");
        AterrizarSound = Resources.Load<AudioClip>("Aterrizar");
        GanchoSound = Resources.Load<AudioClip>("Gancho");
        SoltarganchoSound = Resources.Load<AudioClip>("Soltargancho");
        ColisionbalaSound = Resources.Load<AudioClip>("Colsionbala");
        DerribadoSound = Resources.Load<AudioClip>("Derribado");

        //CAJAS
        AparecercajaSound = Resources.Load<AudioClip>("Aparececaja");
        RecojecajaSound = Resources.Load<AudioClip>("Recojecaja");
        //PandaCorreSound = Resources.Load<AudioClip>("Panda_pasto");
        //PowerupSound = Resources.Load<AudioClip>("ImpacObstac");

        audioScr = GetComponent<AudioSource>();
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            //JJUGADORES
            case "Direccion": audioScr.PlayOneShot(DireccionSound);
                break;

            case "Aterrizar":
                audioScr.PlayOneShot(AterrizarSound);
                break;

            case "Gancho":
                audioScr.PlayOneShot(GanchoSound);
                break;

            case "Soltargancho":
                audioScr.PlayOneShot(SoltarganchoSound);
                break;

            case "Colsionbala":
                audioScr.PlayOneShot(ColisionbalaSound);
                break;

                case "Derribado":
                    audioScr.PlayOneShot(DerribadoSound);
                    break;
                //CAJAS
                case "Aparececaja":
                    audioScr.PlayOneShot(AparecercajaSound);
                    break;

                case "Recojecaja":
                    audioScr.PlayOneShot(RecojecajaSound);
                    break;

    //            //case "Panda_pasto":
    //            //    audioScr.PlayOneShot(PandaCorreSound);
    //            //    break;

    //            //case "ImpacObstac":
    //            //    audioScr.PlayOneShot(PowerupSound);
    //            //    break;
        }
    }
}
