using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject optionsPanel; // Panel de opciones (puede estar desactivado al inicio)

    // M�todo para iniciar el juego
    public void PlayGame()
    {
        Debug.Log("Iniciando el juego...");
        SceneManager.LoadScene("GameScene"); // Reemplaza "GameScene" con el nombre de tu escena de juego
    }

    // M�todo para mostrar las opciones
    public void ShowOptions()
    {
        if (optionsPanel != null)
        {
            optionsPanel.SetActive(true); // Mostrar el panel de opciones
        }
    }

    // M�todo para salir de las opciones
    public void CloseOptions()
    {
        if (optionsPanel != null)
        {
            optionsPanel.SetActive(false); // Ocultar el panel de opciones
        }
    }

    // M�todo para salir del juego
    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit(); // Esto solo funciona en una compilaci�n, no en el editor
    }
}
