
using UnityEngine;
using System.Collections.Generic;

public class GrupoEnemigos : MonoBehaviour
{
    public SpawnEnemigos spawnManager;
    public float speed = 2f;
    public float speedIncremented = 0;
    public float dropDistance = 0.5f;
    public float screenLimit = 8f;
    public float gameOverLimit = -4f;

    private int direction = 1;
    private bool isGameOver = false;
    bool aumentaVelocidad;

    public int numeroDeenemigos = 0;
    private void Start()
    {
    }

    void Update()
    {
        numeroDeenemigos = transform.childCount;
        if (numeroDeenemigos <= 0)
        {
            GameManager.Instance.estaGanado = true;
        }
        if (isGameOver || transform.childCount == 0) return;

        // Mover y cambiar dirección
        float leftmostX = float.MaxValue;
        float rightmostX = float.MinValue;
        float bottomMostY = float.MinValue;

        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                leftmostX = Mathf.Min(leftmostX, child.position.x);
                rightmostX = Mathf.Max(rightmostX, child.position.x);
                bottomMostY = Mathf.Max(bottomMostY, child.position.y);

                if (bottomMostY <= gameOverLimit)
                {
                    TriggerGameOver();
                    return;
                }
            }
        }

        if (rightmostX > screenLimit || leftmostX < -screenLimit)
        {
            direction *= -1;
            transform.Translate(Vector3.down * dropDistance);
        }
        speedIncremented = speed;
        
        transform.Translate(Vector3.right * direction * speedIncremented * Time.deltaTime);

        // Actualizar los cubos más bajos en cada columna que pueden disparar
        ActualizarEnemigos(spawnManager);
    }

    private void TriggerGameOver()
    {
        isGameOver = true;
        Debug.Log("¡Game Over!");
        // Aquí podrías añadir tu lógica de UI para Game Over.
    }

    private void ActualizarEnemigos(SpawnEnemigos spawnManager)
    {
        // Iterar columna por columna
        for (int col = 0; col < spawnManager.columns; col++)
        {
            GameObject lowestEnemy = null;

            // Iterar por filas de abajo hacia arriba
            for (int fila = 0; fila < spawnManager.filas; fila++) // Cambié aquí a `fila++` para empezar desde abajo
            {
                GameObject enemy = spawnManager.enemigos[fila][col];

                // Si encontramos un enemigo en esta fila, es el más bajo de la columna
                if (enemy != null)
                {
                    lowestEnemy = enemy;
                    break; // Salimos del bucle al encontrar el más bajo
                }
            }

            // Actualizar el disparo para los enemigos en esta columna
            for (int fila = 0; fila < spawnManager.filas; fila++)
            {
                GameObject enemy = spawnManager.enemigos[fila][col];
                if (enemy != null)
                {
                    DisparoEnemigo disparoEnemigo = enemy.GetComponent<DisparoEnemigo>();
                    if (disparoEnemigo != null)
                    {
                        disparoEnemigo.canShoot = (enemy == lowestEnemy);
                    }
                }
            }
        }
    }

    public void AjustarVelocidad(int total)
    {
        total++;
        if (total >= 1)
        {
            speed = speed + total * 0.1f;

        }

        
    }
}