using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedStart : MonoBehaviour
{
    [SerializeField] private GameObject countDownObject;
    [SerializeField] private float countDowntime = 3f;

    void Start()
    {
        countDownObject.SetActive(true);
        StartCoroutine("StartDelay");
    }

    IEnumerator StartDelay()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + countDowntime;
        while (Time.realtimeSinceStartup < pauseTime)
        {
            yield return 0;
        }
        countDownObject.SetActive(false);
        Time.timeScale = 1;
    }
}
