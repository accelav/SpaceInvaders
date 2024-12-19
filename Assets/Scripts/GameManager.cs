using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Instancia para acceso global
    public GameObject gameOverUI; // Referencia al texto de Game Over

    bool naveUno = false;
    bool naveDos = false;
    bool naveTres = false;

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
    private void Update()
    {
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

    public void seleccionDeNave(int nave)
    {
        if (nave == 0)
        {
            naveUno = true;
        }
        if (nave == 1)
        {
            naveDos = true;
        }
        if (nave == 2)
        {
            naveTres = true;
        }
    }
}
