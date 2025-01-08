using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComportamientoCañon : MonoBehaviour
{
    float velocidad = 100;
    public float minRotation = -70f; // Límite inferior en grados
    public float maxRotation = 70f;  // Límite superior en grados

    void Update()
    {
        // Obtener la entrada del jugador
        float mov = Input.GetAxisRaw("Horizontal") * velocidad * Time.deltaTime;

        // Calcular la rotación actual en el eje Z
        float currentRotation = transform.eulerAngles.z;

        // Convertir el rango de 0-360 a -180 a 180 para manejar correctamente los límites
        if (currentRotation > 180f) currentRotation -= 360f;

        // Calcular la nueva rotación dentro de los límites
        float newRotation = Mathf.Clamp(currentRotation + -mov, minRotation, maxRotation);

        // Aplicar la rotación limitada
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, newRotation);
  
    }
}
