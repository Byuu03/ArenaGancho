using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CineMachineMovimientoCamara : MonoBehaviour
{
    public static CineMachineMovimientoCamara Instance;

    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;

    private float tiempoMovimiento;
    private float tiempoMovimientoTotal;
    private float intensidadInicial;

    private void Awake()
    {
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoMovimiento > 0)
        {
            tiempoMovimiento -= Time.deltaTime;
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(intensidadInicial, 0, 1 - (tiempoMovimiento / tiempoMovimientoTotal));
        }
    }


    public void MoverCamara(float intensidad, float frecuencia, float tiempo)
    {
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensidad;
        cinemachineBasicMultiChannelPerlin.m_FrequencyGain = frecuencia;
        intensidadInicial = intensidad;
        tiempoMovimientoTotal = tiempo;
        tiempoMovimiento = tiempo;
    }

    

}
