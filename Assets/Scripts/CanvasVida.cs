using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasVida : MonoBehaviour
{
    [SerializeField]
    GameObject Corazones; // Prefab del corazón
    int vidasActuales = -1; // Vida inicial

    void Update()
    {
        int vidasEnGameManager = GameManager.Instance.vidaActual;

        if (vidasActuales != vidasEnGameManager)
        {
            vidasActuales = vidasEnGameManager;
            ActualizarCorazones();
        }
    }

    void ActualizarCorazones()
    {

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }


        for (int fila = 0; fila < vidasActuales; fila++)
        {
            Vector3 posicion = new Vector3((9.5f - fila ), 6f, 0f);
            Instantiate(Corazones, posicion, Quaternion.identity, transform);
        }
    }
}

