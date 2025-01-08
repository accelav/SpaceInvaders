using UnityEngine;

public class GrupoEnemigos : MonoBehaviour
{
    public float speed = 2f; // Velocidad de movimiento horizontal
    public float dropDistance = 0.5f; // Distancia que el grupo baja al cambiar de dirección
    public float screenLimit = 8f; // Límite horizontal para el grupo
    public float gameOverLimit = -4f; // Límite inferior para Game Over

    private int direction = 1; // Dirección inicial (1: derecha, -1: izquierda)
    private bool isGameOver = false; // Estado del juego

    void Update()
    {
        if (isGameOver || transform.childCount == 0) return; // Si es Game Over, no hacer nada

        // Inicializar límites
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

                // Verificar si algún enemigo alcanzó el límite inferior
                if (bottomMostY <= gameOverLimit)
                {
                    TriggerGameOver();
                    return;
                }
            }
        }

        // Cambiar de dirección y bajar si se alcanzan los límites
        if (rightmostX > screenLimit || leftmostX < -screenLimit)
        {
            direction *= -1;
            transform.Translate(Vector3.down * dropDistance);
        }

        // Mover el grupo horizontalmente
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
    }

    private void TriggerGameOver()
    {
        isGameOver = true;
        Debug.Log("¡Game Over!"); // Mostrar en la consola
        // Aquí podrías llamar a una función para mostrar el mensaje de Game Over en la UI
        GameManager.Instance.ShowGameOverUI(); // (Suponiendo que tengas un GameManager para manejar la UI)
    }
}
