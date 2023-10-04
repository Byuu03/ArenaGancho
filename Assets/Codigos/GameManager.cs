using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    //Jugadores
    public GameObject player1;
    public GameObject player2;

    //Vidas
    public int P1Life;
    public int P2Life;

    //Sprites
    public GameObject[] p1Stock;
    public GameObject[] p2Stock;

    //public Slider barrahp;

    // private int scoreOne;
    // private int scoreTwo;

    //Puntos Jugadores

    //public TMP_Text scoreTextPlayerOne;
    //public TMP_Text scoreTextPlayerTwo;


    //Timer
    //public TextMeshProUGUI timerText;
    //public float gameTime;
    //private bool stopTimer;

    //Pantallas
    public GameObject p1Wins;
    public GameObject p2Wins;
    //public WinScreen WinEndScreen;
    //public GameoverScreen GameOverScreen;


    private void Awake()
    {
        manager = this;
        //score = 0;
        //scoreOne = 0;
        //scoreTwo = 0;
        //UpdatedScore();
        //Application.targetFrameRate = 60;


    }

    public void Start()
    {
        Time.timeScale = 1;
        //stopTimer = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    //public int vidas;
    //public void GameOver()
    //{
    //    print("EndGame");
    //    Cursor.visible = true;
    //    Cursor.lockState = CursorLockMode.None;
    //    //GameOverScreen.Setup(score);
    //}


    //public void WinGame()
    //{
    //    print("WinGame");
    //    Cursor.visible = true;
    //    Cursor.lockState = CursorLockMode.None;
    //    //WinEndScreen.Setup(score);
    //}

    //public void ResetearJuego()
    //{

    //}

    //public void QuitarVidas(int restarhp)
    //{
    //    vidas -= restarhp;
    //    barrahp.value = vidas;
    //    //Audiomanager.PlaySound("Daño");
    //    if (vidas < 1)
    //    {
    //        GameOver();
    //        //Over.Show();
    //    }
    //}

    //public void RestaurarHp(int sanar)
    //{
    //    //GameManager.manager.RestaurarVidas();

    //    vidas += sanar;
    //    barrahp.value = vidas;
    //}

    private void Update()
    {
        if (P1Life <= 0)
        {
            player1.SetActive(false);
            p2Wins.SetActive(true);
        }

        if (P2Life <= 0)
        {
            player2.SetActive(false);
            p1Wins.SetActive(true);
        }

    }

    public void HurtP1()
    {
        P1Life -= 1;

        for (int i = 0; i < p1Stock.Length; i++)
        {
            if (P1Life > i)
            {
                p1Stock[i].SetActive(true);
            }
            else
            {
                p1Stock[i].SetActive(false);
            }
        }
    }

    public void HurtP2()
    {
        P2Life -= 1;

        for (int i = 0; i < p2Stock.Length; i++)
        {
            if (P2Life > i)
            {
                p2Stock[i].SetActive(true);
            }
            else
            {
                p2Stock[i].SetActive(false);
            }
        }
    }


    //NO OLVIDAR LOS TAGS

}
