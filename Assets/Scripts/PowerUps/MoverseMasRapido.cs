using UnityEngine;

public class FasterMovement : MonoBehaviour
{
    public float duration = 10f; // Duración del efecto en segundos.
    public float speedMultiplier = 2f; // Multiplicador de la velocidad.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                StartCoroutine(EnhanceSpeed(player));
            }
            Destroy(gameObject); // Destruye el power-up después de usarlo.
        }
    }

    private System.Collections.IEnumerator EnhanceSpeed(PlayerController player)
    {
        player.movementSpeed *= speedMultiplier;
        yield return new WaitForSeconds(duration);
        player.movementSpeed /= speedMultiplier;
    }
}
