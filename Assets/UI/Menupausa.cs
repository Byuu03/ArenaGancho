using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menupausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    private bool juegoPausado = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            }
        }
    }



    public void Pausa()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true); //Aqui se activa
        
    }

    public void Reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        //Audiomanager.PlaySound("Botones");
        menuPausa.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Reiniciar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        //Audiomanager.PlaySound("Botones");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Cerrar()
    {
        //Audiomanager.PlaySound("Botones");
        Application.Quit();
        Debug.Log("Sali");
    }


}
