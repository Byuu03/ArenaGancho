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
    public static AudioClip MoverseSound;

    //CAJAS
    public static AudioClip AparecercajaSound;
    public static AudioClip RecojecajaSound;
    public static AudioClip SlimeSound;

    //BALAS
    public static AudioClip FlechaSound;
    public static AudioClip ExplotionSound;
    public static AudioClip ParalisisSound;
    public static AudioClip ConfuseSound;
    public static AudioClip SlowerSound;

    //ARMAS
    public static AudioClip DisparosimpleSound;
    public static AudioClip BowSound;

    //UI
    public static AudioClip BotonesSound;

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
        MoverseSound = Resources.Load<AudioClip>("Moverse");

        //CAJAS
        AparecercajaSound = Resources.Load<AudioClip>("Aparececaja");
        RecojecajaSound = Resources.Load<AudioClip>("Recojecaja");
        SlimeSound = Resources.Load<AudioClip>("Slime");

        //BALAS
        FlechaSound = Resources.Load<AudioClip>("Flecha");
        ExplotionSound = Resources.Load<AudioClip>("Explotion");
        ParalisisSound = Resources.Load<AudioClip>("Paralisis");
        ConfuseSound = Resources.Load<AudioClip>("Confuse");
        SlowerSound = Resources.Load<AudioClip>("Slower");

        //Armas
        DisparosimpleSound = Resources.Load<AudioClip>("Disparosimple");
        BowSound = Resources.Load<AudioClip>("Bow");

        //UI
        BotonesSound = Resources.Load<AudioClip>("Botones");

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

            case "Moverse":
                audioScr.PlayOneShot(MoverseSound);
                break;

            //CAJAS
            case "Aparececaja":
                    audioScr.PlayOneShot(AparecercajaSound);
                    break;

                case "Recojecaja":
                    audioScr.PlayOneShot(RecojecajaSound);
                    break;

            case "Slime":
                audioScr.PlayOneShot(SlimeSound);
                break;

            //BALAS
            case "Flecha":
                    audioScr.PlayOneShot(FlechaSound);
                    break;

                case "Explotion":
                    audioScr.PlayOneShot(ExplotionSound);
                    break;

            case "Paralisis":
                audioScr.PlayOneShot(ParalisisSound);
                break;

            case "Confuse":
                audioScr.PlayOneShot(ConfuseSound);
                break;

            case "Slower":
                audioScr.PlayOneShot(ConfuseSound);
                break;

            //Armas
            case "Disparosimple":
                audioScr.PlayOneShot(DisparosimpleSound);
                break;

            case "Bow":
                audioScr.PlayOneShot(BowSound);
                break;

            //UI
            case "Botones":
                audioScr.PlayOneShot(BotonesSound);
                break;
        }
    }
}
