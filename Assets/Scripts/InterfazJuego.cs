using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InterfazJuego : MonoBehaviour
{

    public ComportamientoJugador ComportamientoJugador;
    [SerializeField]
    TextMeshProUGUI textoTiempo;

    float timer = 0;

    [SerializeField]
    GameObject imagenVida;
    GameObject vida;

    int vidaMaxima;
    int vidaActual;

    [SerializeField]
    TextMeshProUGUI textoPuntos;

    [SerializeField]
    TextMeshProUGUI textoTiempoBomba;
    private void Start()
    {
        //vidaActual = GameManager.Instance.vidaActual;
        GameManager.Instance.estaPerdido = false;
        ComportamientoJugador = FindAnyObjectByType<ComportamientoJugador>();
    }
    private void Update()
    {
        
        textoPuntos.text = GameManager.Instance.puntosActuales.ToString();
        textoTiempo.text = timer.ToString("00");
        textoTiempoBomba.text = ("Tiempo Power Bomb" + ComportamientoJugador.timer2.ToString("00"));
        vida = imagenVida;

        if (GameManager.Instance.estaPerdido == true)
        {
            timer = timer;
        }
        else
        {
            timer += Time.deltaTime;
        }

    }
    public void PausarPartida()
    {
        SceneController.Instance.TogglePause();

    }
    public void VolverAEmpezar()
    {
        SceneController.Instance.ReloadCurrentScene();
        SceneController.Instance.isPaused = false;
    }

    public void VolverMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
        SceneController.Instance.isPaused = false;
    }
}
