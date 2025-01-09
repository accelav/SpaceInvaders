using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUps : MonoBehaviour
{
    [SerializeField]
    GameObject[] powerUps;
    GameObject powerUp;
    public float timer = 0;
    public int rangoMin = 10;
    public int rangoMax = 20;
    public int numeroAleatorio = 10;
    public int powerUpAleatorio = 0;
    bool cambiandoAleatorio = false;
    void Start()
    {
        numeroAleatorio = Random.Range(rangoMin, rangoMax);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= numeroAleatorio)
        {
            InstanciarPowerUp();
            cambiandoAleatorio = true;
            timer = 0;
        }
        if (cambiandoAleatorio)
        {
            cambiandoAleatorio = false;
            powerUpAleatorio = Random.Range(0, powerUps.Length);
            numeroAleatorio = Random.Range(rangoMin, rangoMax);
            

        }
    }

    public void InstanciarPowerUp()
    {
        
        powerUp = Instantiate(powerUps[powerUpAleatorio], gameObject.transform.position, Quaternion.identity);
    }

}
