using UnityEngine;

public class SpawnEnemigos : MonoBehaviour
{
    public GameObject enemyType1Prefab; // Prefab para las filas inferiores
    public GameObject enemyType2Prefab; // Prefab para la fila superior
    public int rows = 5; // N�mero de filas
    public int columns = 8; // N�mero de columnas
    public float spacingX = 1.5f; // Espaciado entre enemigos en X
    public float spacingY = 1.5f; // Espaciado entre enemigos en Y
    public Vector3 startPosition = new Vector3(-6f, -4f, 0f); // Posici�n inicial de la cuadr�cula

    void Start()
    {
        GenerateEnemies();
    }

    void GenerateEnemies()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                // Calcular la posici�n del enemigo
                // Invertir las filas para que la fila 0 est� abajo y la fila rows-1 est� arriba
                Vector3 position = startPosition + new Vector3(col * spacingX, row * spacingY, 0);

                // Seleccionar el prefab: usa el prefab tipo 2 solo para la fila superior
                GameObject prefabToInstantiate = (row == rows - 1) ? enemyType2Prefab : enemyType1Prefab;

                // Instanciar el enemigo como hijo del grupo
                if (prefabToInstantiate != null)
                {
                    Instantiate(prefabToInstantiate, position, Quaternion.identity, transform);
                }
            }
        }
    }
}
