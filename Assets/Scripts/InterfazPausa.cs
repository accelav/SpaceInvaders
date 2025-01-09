using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfazPausa : MonoBehaviour
{
    public void RegresarAtras()
    {
        SceneController.Instance.TogglePause();
    }

    public void RegresarMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
        SceneController.Instance.isPaused = false;
    }
}