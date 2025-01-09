using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantallasNivel : MonoBehaviour
{
    public GrupoEnemigos grupoEnemigos;
    [SerializeField]
    GameObject panelGameOver;
    [SerializeField]
    GameObject panelNivelSuperado;
    float timer = 0;
    void Start()
    {
        
    }

    
    void Update()
    {
        

        if (GameManager.Instance.vidaActual <= 0)
        {
            panelGameOver.SetActive(true);
        }
        else
        {
            panelGameOver.SetActive(false);
        }

        if (grupoEnemigos.numeroDeenemigos == 0)
        {
            timer += Time.deltaTime;
            panelNivelSuperado.SetActive(true);

            if (timer >= 3)
            {
                panelNivelSuperado.SetActive(false);

            }
        }
        else
        {
            panelNivelSuperado.SetActive(false);
        }
    }
}
