using UnityEngine;

public class RepairBunker : MonoBehaviour
{
    public GameObject[] bunkerPieces; // Array de piezas del b�nker a reparar.

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
            Destroy(gameObject); // Destruye el power-up despu�s de usarlo.
        }
    }
}
