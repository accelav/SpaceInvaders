using UnityEngine;

public class SaludJugador : MonoBehaviour
{
    public InterfazJuego interfazJuego;
    public int vidaMaxima = 3; // Vida máxima del jugador
    public int vidaActual;

    
    void Start()
    {
        // Inicializar la salud
        vidaActual = vidaMaxima;
    }

    private void Update()
    {
        
    }
    public void RecibirDaño(int damage)
    {
        vidaActual -= damage;
        Debug.Log("Vida del jugador: " + vidaActual);

        // interfazJuego.AparicionVidas(vidaActual);

        if (vidaActual <= 0)
        {
            Debug.Log("¡Jugador destruido!");
            // Aquí podrías detener el juego o mostrar una pantalla de Game Over
        }
    }
}
