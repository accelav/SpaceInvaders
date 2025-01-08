using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnEnemigos : MonoBehaviour
{
    
    public GameObject enemyType1Prefab; // Prefab para las filas inferiores
    public GameObject enemyType2Prefab; // Prefab para la fila superior
    public int filas = 5; // Número de filas
    public int columns = 8; // Número de columnas
    public float spacingX = 1.5f; // Espaciado entre enemigos en X
    public float spacingY = 1.5f; // Espaciado entre enemigos en Y
    public Vector3 startPosition = new Vector3(-6f, -4f, 0f); // Posición inicial de la cuadrícula

    // Lista bidimensional para almacenar los cubos por filas y columnas
    public List<List<GameObject>> enemigos = new List<List<GameObject>>();

    void Start()
    {
        GenerateEnemies();
    }

    void GenerateEnemies()
    {
        for (int fila = 0; fila < filas; fila++)
        {
            List<GameObject> filaEnemigos = new List<GameObject>();

            for (int col = 0; col < columns; col++)
            {
                Vector3 position = startPosition + new Vector3(col * spacingX, fila * spacingY, 0);
                GameObject prefabToInstantiate = (fila == 0) ? enemyType2Prefab : enemyType1Prefab;

                if (prefabToInstantiate != null)
                {
                    GameObject enemy = Instantiate(prefabToInstantiate, position, Quaternion.identity, transform);
                    filaEnemigos.Add(enemy); // Agregar a la lista de la fila
                }
                else
                {
                    filaEnemigos.Add(null); // En caso de que no haya prefab
                }
            }

            enemigos.Add(filaEnemigos); // Agregar la fila completa a la lista de enemigos
        }
    }
}
