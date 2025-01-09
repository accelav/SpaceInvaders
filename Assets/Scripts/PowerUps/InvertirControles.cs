using UnityEngine;

public class InvertControls : MonoBehaviour
{
    public float duration = 5f; // Duración del efecto en segundos.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                StartCoroutine(InvertPlayerControls(player));
            }
            Destroy(gameObject); // Destruye el power-up después de usarlo.
        }
    }

    private System.Collections.IEnumerator InvertPlayerControls(PlayerController player)
    {
        player.controlsInverted = true;
        yield return new WaitForSeconds(duration);
        player.controlsInverted = false;
    }
}


/* Copiar en script comportamientojugador
// Dentro del PlayerController
public bool controlsInverted = false;

void Update()
{
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");

    if (controlsInverted)
    {
        horizontal = -horizontal;
        vertical = -vertical;
    }

    // Movimiento del jugador basado en horizontal y vertical.
}
*/