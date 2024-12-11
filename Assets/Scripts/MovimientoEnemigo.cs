using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public float velocidad = 2f; // Velocidad de movimiento horizontal
    public float distanciaBajada = 0.5f; // Distancia que los enemigos bajan al cambiar de direcci�n
    public float limitePantalla = 8f; // L�mite horizontal para el grupo de enemigos

    private int direccion = 1; // Direcci�n inicial (1: derecha, -1: izquierda)

    void Update()
    {
        // Mover el grupo de enemigos de lado a lado
        transform.Translate(Vector3.right * direccion * velocidad * Time.deltaTime);

        // Comprobar si el grupo ha alcanzado los l�mites de la pantalla
        if (transform.position.x > limitePantalla || transform.position.x < -limitePantalla)
        {
            // Cambiar direcci�n
            direccion *= -1;

            // Hacer que los enemigos bajen un nivel
            transform.Translate(Vector3.down * distanciaBajada);
        }
    }
}
