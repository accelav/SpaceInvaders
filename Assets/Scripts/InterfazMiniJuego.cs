using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InterfazMiniJuego : MonoBehaviour
{


    private void Start()
    {
        //vidaActual = GameManager.Instance.vidaActual;
    }
    private void Update()
    {


    }
    public void PausarPartida()
    {
        SceneController.Instance.TogglePause();

    }

}
