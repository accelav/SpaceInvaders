using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    [SerializeField]
    GameObject proyectilJugador;

    private Transform puntoDisparo;

    public float timer = 2;

    void Start()
    {
        puntoDisparo = transform.Find("ProyectilJugador");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (timer >= 2)
            {
                Instantiate(proyectilJugador, puntoDisparo.position, puntoDisparo.rotation);
                timer = 0;
            }
                
        }
    }
}
