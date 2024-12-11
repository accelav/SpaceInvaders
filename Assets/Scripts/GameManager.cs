using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Instancia para acceso global
    public GameObject gameOverUI; // Referencia al texto de Game Over

    private void Awake()
    {
        // Configurar Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowGameOverUI()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true); // Mostrar el texto de Game Over
        }

        // Detener el tiempo (opcional)
        Time.timeScale = 0f;
    }
}
