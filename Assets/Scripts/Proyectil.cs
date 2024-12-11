using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{

    public float velocidad = 10f; // Velocidad del proyectil
    public float tiempoDeVida = 5f; // Tiempo de vida antes de destruirse automáticamente

    void Start()
    {
        // Destruir el proyectil automáticamente después de un tiempo
        Destroy(gameObject, tiempoDeVida);
    }

    void Update()
    {
        // Mover el proyectil hacia adelante según su velocidad
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
                saludJugador.RecibirDaño(1); // Aplica 1 punto de daño
            }
            Destroy(gameObject);
        }
    }


}
