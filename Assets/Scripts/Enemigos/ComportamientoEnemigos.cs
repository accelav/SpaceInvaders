using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ComportamientoEnemigos : MonoBehaviour
{
    public GrupoEnemigos grupoEnemigos;
    public Bomba Bomba;
    public int puntos = 100;
    float timer = 0;
    void Start()
    {
        grupoEnemigos = FindAnyObjectByType<GrupoEnemigos>();
        Bomba = FindAnyObjectByType<Bomba>();
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

        if (other.gameObject.CompareTag("Explosion"))
        {
            Destroy(gameObject);
        }
    }
}
