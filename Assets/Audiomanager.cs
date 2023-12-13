using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    public static AudioClip DireccionSound;
    public static AudioClip AterrizarSound;
    public static AudioClip GanchoSound;
    //public static AudioClip AlertaSound;
    //public static AudioClip BotonesSound;
    ////public static AudioClip MuroSound;
    ////public static AudioClip PandaSound;
    ////public static AudioClip BotonesSound;
    ////public static AudioClip PandaCorreSound;
    ////public static AudioClip PowerupSound;

    static AudioSource audioScr;
    //// Start is called before the first frame update
    void Start()
    {
        DireccionSound = Resources.Load<AudioClip>("Direccion");
        AterrizarSound = Resources.Load<AudioClip>("Aterrizar");
        GanchoSound = Resources.Load<AudioClip>("Gancho");
        //AlertaSound = Resources.Load<AudioClip>("Alert");
        //BotonesSound = Resources.Load<AudioClip>("Botones");
        //MuroSound = Resources.Load<AudioClip>("ImpacMuro");
        //PandaSound = Resources.Load<AudioClip>("Panda");
        //BotonesSound = Resources.Load<AudioClip>("Botones");
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
            case "Direccion": audioScr.PlayOneShot(DireccionSound);
                break;

            case "Aterrizar":
                audioScr.PlayOneShot(AterrizarSound);
                break;

            case "Gancho":
                audioScr.PlayOneShot(GanchoSound);
                break;

    //        case "Alert":
    //            audioScr.PlayOneShot(AlertaSound);
    //            break;

    //        case "Botones":
    //            audioScr.PlayOneShot(BotonesSound);
    //            break;

    //            //case "ImpacMuro":
    //            //    audioScr.PlayOneShot(MuroSound);
    //            //    break;

    //            //case "Panda":
    //            //    audioScr.PlayOneShot(PandaSound);
    //            //    break;

    //            //case "Botones":
    //            //    audioScr.PlayOneShot(BotonesSound);
    //            //    break;

    //            //case "Panda_pasto":
    //            //    audioScr.PlayOneShot(PandaCorreSound);
    //            //    break;

    //            //case "ImpacObstac":
    //            //    audioScr.PlayOneShot(PowerupSound);
    //            //    break;
        }
    }
}
