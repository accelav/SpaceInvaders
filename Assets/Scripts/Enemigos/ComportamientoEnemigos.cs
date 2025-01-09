using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoEnemigos : MonoBehaviour
{
    public GrupoEnemigos grupoEnemigos;
    public int puntos = 100;
    void Start()
    {
        grupoEnemigos = FindAnyObjectByType<GrupoEnemigos>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ProyectilJugador"))
        {
            grupoEnemigos.AjustarVelocidad(1);
            GameManager.Instance.SumarPuntos(puntos);

            Destroy(gameObject);
        }
    } 
}
