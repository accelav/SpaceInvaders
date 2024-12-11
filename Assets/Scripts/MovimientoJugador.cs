using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 10f; // Velocidad de movimiento
    public float screenLimit = 8f; // Límite horizontal del movimiento

    void Update()
    {
        // Obtener la entrada horizontal (A/D o Flechas izquierda/derecha)
        float input = Input.GetAxisRaw("Horizontal");

        // Mover al jugador en función de la velocidad y la entrada
        transform.Translate(Vector3.right * input * velocidad * Time.deltaTime);

        // Restringir el movimiento dentro de los límites de la pantalla
        float clampedX = Mathf.Clamp(transform.position.x, -screenLimit, screenLimit);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
