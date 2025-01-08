using System;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Instancia para acceso global
    public GameObject gameOverUI; // Referencia al texto de Game Over


    [SerializeField]
    GameObject[] naves;

    public int vidaActual;

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

    public void SeleccionDeNave(int nave)
    {
        for (int i = 0; i < naves.Length; i++)
        {
            if (i == nave)
            {
                naves[i].SetActive(true);

            }
            else
            {
                naves[i].SetActive(false);
            }
        }

    }

    public void GestionarVidas( int vidas)
    {
        vidaActual -= vidas;
    }

    public void SaberVidaMaxima( int vidaMaxima)
    {
        vidaActual = vidaMaxima;
        Debug.Log(vidaMaxima);
    }
}
