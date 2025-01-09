using UnityEngine;

public class FasterMovement : MonoBehaviour
{
    public float duration = 10f; // Duraci�n del efecto en segundos.
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
            Destroy(gameObject); // Destruye el power-up despu�s de usarlo.
        }
    }

    private System.Collections.IEnumerator EnhanceSpeed(PlayerController player)
    {
        player.movementSpeed *= speedMultiplier;
        yield return new WaitForSeconds(duration);
        player.movementSpeed /= speedMultiplier;
    }
}
