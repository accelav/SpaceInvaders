using UnityEngine;

public class SaludJugador : MonoBehaviour
{
    public int vidaMaxima = 3; // Vida m�xima del jugador
    private int vidaActual;

    void Start()
    {
        // Inicializar la salud
        vidaActual = vidaMaxima;
    }

    public void RecibirDa�o(int damage)
    {
        vidaActual -= damage;
        Debug.Log("Vida del jugador: " + vidaActual);

        if (vidaActual <= 0)
        {
            Debug.Log("�Jugador destruido!");
            // Aqu� podr�as detener el juego o mostrar una pantalla de Game Over
        }
    }
}
