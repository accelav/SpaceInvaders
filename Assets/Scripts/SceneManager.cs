using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    public bool isPaused = false; // Estado de pausa
    private string previousScene;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantener el objeto al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Eliminar duplicados
        }
    }

    private void Start()
    {
        isPaused = false;
        ManageEventSystems();
    }

    public void LoadScene(string sceneName)
    {
        
        if (sceneName != "Options")
        {
            previousScene = SceneManager.GetActiveScene().name;
        }

        Debug.Log($"Cargando escena: {sceneName}");
        SceneManager.LoadScene(sceneName);
    }

    public void LoadPreviousScene()
    {
        Time.timeScale = 1.0f;
        if (!string.IsNullOrEmpty(previousScene))
        {
            Debug.Log($"Volviendo a la escena previa: {previousScene}");
            SceneManager.LoadScene(previousScene);
        }
        else
        {
            Debug.LogWarning("No hay una escena previa guardada.");
        }
    }

    public void ReloadCurrentScene()
    {
        
        string currentScene = SceneManager.GetActiveScene().name;
        Debug.Log($"Recargando escena: {currentScene}");
        SceneManager.LoadScene(currentScene);
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f; // Detiene el tiempo
            isPaused = true;
            Debug.Log("Juego pausado.");
            previousScene = SceneManager.GetActiveScene().name;

            SceneManager.LoadScene("Opciones", LoadSceneMode.Additive);
            ManageEventSystems(); // Ajusta los EventSystems
        }
    }

    public void ResumeGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1f; // Restaura el tiempo
            isPaused = false;
            Debug.Log("Juego reanudado.");

            if (SceneManager.GetSceneByName("Opciones").isLoaded)
            {
                SceneManager.UnloadSceneAsync("Opciones");
            }

            ManageEventSystems(); // Ajusta los EventSystems
        }
    }

    private void ManageEventSystems()
    {
        // Buscar todos los EventSystems activos en la escena
        EventSystem[] eventSystems = FindObjectsOfType<EventSystem>();

        if (eventSystems.Length > 1)
        {
            Debug.LogWarning("Se detectaron múltiples EventSystems. Desactivando los duplicados...");
            for (int i = 1; i < eventSystems.Length; i++)
            {
                eventSystems[i].gameObject.SetActive(false);
            }
        }
    }
}
