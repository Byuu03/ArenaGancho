using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    private Animator anim;
    [SerializeField] string nivel;

    public bool juegoPausado = false;
    public float tiempo_start = 0f;
    public float tiempo_end = 0f;
    //public int sceneIndex = 0;
    // int escenaACargardespuesdelfadeout;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PasarNivel()
    {
        SceneManager.LoadScene(nivel);
    }

    public void HacerFade()
    {
        anim.SetTrigger("fadeout");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //juegoPausado = true;
        //Time.timeScale = 0f;
        Debug.Log("tiempo_start");
        tiempo_start += Time.deltaTime;
        if (tiempo_start >= tiempo_end)
        {
            juegoPausado = true;
            Time.timeScale = 1f;
        }
    }
}
