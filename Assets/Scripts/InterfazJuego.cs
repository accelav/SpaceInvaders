using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InterfazJuego : MonoBehaviour
{


    [SerializeField]
    TextMeshProUGUI textoTiempo;

    float timer = 0;

    [SerializeField]
    GameObject imagenVida;
    GameObject vida;

    int vidaMaxima;
    int vidaActual;

    private void Start()
    {
        vidaActual = GameManager.Instance.vidaActual;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        textoTiempo.text = timer.ToString("00");
        vida = imagenVida;

    }
    public void PausarPartida()
    {
        SceneController.Instance.TogglePause();

    }

    public void AparicionVidas(int vidaActual)
    {
        for (int i = 0; i < vidaActual; i++)
        {

            /*if (vida != null)
            {
                Destroy(vida);
            }*/

                Instantiate(vida, imagenVida.transform.position, Quaternion.identity);
            

            /*if (i == vidaActual)
            {
                return;
            }*/
        }
    }
}
