using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objetos;
    public GameObject obje;
    public float timer = 0f;
    public float timeToSpawn = 6f;

    public GameObject aux;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToSpawn && aux == null)
        {
            int indice = Random.Range(0, objetos.Length);
            aux = Instantiate(objetos[indice], transform.position, Quaternion.identity);
            timer = 0f;
          // Destroy(objeto, 6f);
        }
    }
}
