using UnityEngine;

public class FasterShooting : MonoBehaviour
{
    public float duration = 10f; // Duración del efecto en segundos.
    public float fireRateMultiplier = 0.5f; // Reduce el tiempo entre disparos.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                StartCoroutine(EnhanceShooting(player));
            }
            Destroy(gameObject); // Destruye el power-up después de usarlo.
        }
    }

    private System.Collections.IEnumerator EnhanceShooting(PlayerController player)
    {
        player.fireRate *= fireRateMultiplier;
        yield return new WaitForSeconds(duration);
        player.fireRate /= fireRateMultiplier;
    }
}
