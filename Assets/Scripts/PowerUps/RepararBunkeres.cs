using UnityEngine;

public class RepairBunker : MonoBehaviour
{
    public GameObject[] bunkerPieces; // Array de piezas del búnker a reparar.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject piece in bunkerPieces)
            {
                if (!piece.activeSelf)
                {
                    piece.SetActive(true);
                }
            }
            Destroy(gameObject); // Destruye el power-up después de usarlo.
        }
    }
}
