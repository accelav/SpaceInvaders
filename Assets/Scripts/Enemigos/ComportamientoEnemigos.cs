using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoEnemigos : MonoBehaviour
{

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ProyectilJugador"))
        {
            Destroy(gameObject);
        }
    }
}
