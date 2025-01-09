using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Instancia para acceso global
    public GameObject gameOverUI; // Referencia al texto de Game Over

    [SerializeField]
    GameObject[] naves;

    public int vidaActual;
    public int puntosActuales; // Puntos acumulados en la partida actual
    public int recordPuntos; // Mejor puntuación registrada

    public int naveSeleccionada;
    public int naveInstanciar;

    public bool estaPerdido = false;
    public bool estaGanado = false;

    private void Awake()
    {
        // Configurar Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Cargar el récord guardado
        recordPuntos = PlayerPrefs.GetInt("RecordPuntos", 0);
    }

    private void Update()
    {
        naveInstanciar = naveSeleccionada;

        if (vidaActual <= 0 && !estaPerdido)
        {
            estaPerdido = true;
            ShowGameOverUI();
        }

        if (estaGanado)
        {
            Debug.Log("¡Has ganado!");
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

        // Actualizar el récord si corresponde
        ActualizarRecord();
    }

    public void SeleccionDeNave(int nave)
    {
        naveSeleccionada = nave;
    }

    public void GestionarVidas(int vidas)
    {
        vidaActual -= vidas;
    }

    public void SaberVidaMaxima(int vidaMaxima)
    {
        vidaActual = vidaMaxima;
        Debug.Log(vidaMaxima);
    }

    // Sistema de Puntos
    public void SumarPuntos(int puntos)
    {
        puntosActuales += puntos;
        Debug.Log($"Puntos actuales: {puntosActuales}");
    }

    public void ActualizarRecord()
    {
        if (puntosActuales > recordPuntos)
        {
            recordPuntos = puntosActuales;
            PlayerPrefs.SetInt("RecordPuntos", recordPuntos);
            PlayerPrefs.Save();
            Debug.Log($"¡Nuevo récord! Puntos: {recordPuntos}");
        }
    }

    public int ObtenerRecord()
    {
        return recordPuntos;
    }

    public void ReiniciarPuntos()
    {
        puntosActuales = 0;
    }
}
