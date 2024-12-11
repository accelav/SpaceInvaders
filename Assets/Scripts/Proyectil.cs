using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{

    public float velocidad = 10f; // Velocidad del proyectil
    public float tiempoDeVida = 5f; // Tiempo de vida antes de destruirse autom�ticamente

    void Start()
    {
        // Destruir el proyectil autom�ticamente despu�s de un tiempo
        Destroy(gameObject, tiempoDeVida);
    }

    void Update()
    {
        // Mover el proyectil hacia adelante seg�n su velocidad
        transform.Translate(Vector3.up * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador impactado!");
            SaludJugador saludJugador = other.GetComponent<SaludJugador>();
            if (saludJugador != null)
            {
                saludJugador.RecibirDa�o(1); // Aplica 1 punto de da�o
            }
            Destroy(gameObject);
        }
    }


}
