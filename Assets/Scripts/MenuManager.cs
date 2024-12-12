using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    private void Start()
    {
        
    }
    public void IniciarPartida()
    {
        Debug.Log("ha Iniciado");
        SceneController.Instance.LoadScene("GameScene"); // Cambia "GameScene" por el nombre de tu escena de juego
    }

    public void ConfigurarPartida()
    {
        SceneController.Instance.TogglePause();
    }

    public void RegresarMenu()
    {
        SceneController.Instance.TogglePause();
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit(); // Esto cierra la aplicación en la compilación
    }
}