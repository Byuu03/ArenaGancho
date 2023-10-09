using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    //public float tiempoStart;
    //public float tiempoEnd;

    //public int sceneIndex;

    private void Start()
    {
        StartCoroutine(ChangeSceneAfterDelay(5));
    }



    private void Update()
    {
        //tiempoStart += Time.deltaTime;
        //if (tiempoStart >= tiempoEnd)
        //{
        //    Application.LoadLevel(sceneIndex
        //}
    }


    public void changeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        //Audiomanager.PlaySound("Botones");
    }

    public void ExitScene()
    {
        Application.Quit();
        Debug.Log("Fui presionado");
        //Audiomanager.PlaySound("Botones");
    }

    IEnumerator ChangeSceneAfterDelay(float seconds)
    {
        

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(seconds);
        //SceneManager.LoadScene(sceneIndex);
        
    }
}
