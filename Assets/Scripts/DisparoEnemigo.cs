using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    public bool canShoot = false; // Determina si este enemigo puede disparar
    public GameObject projectilePrefab; // Prefab del proyectil
    public float minShootInterval = 1f; // Intervalo m�nimo entre disparos
    public float maxShootInterval = 5f; // Intervalo m�ximo entre disparos

    private Transform shootPoint; // Punto desde donde se disparar�
    private float shootTimer = 0f; // Temporizador interno para el disparo
    private float currentShootInterval; // Intervalo de tiempo actual entre disparos

    void Start()
    {
        // Buscar el punto de disparo dentro del enemigo
        shootPoint = transform.Find("Proyectil");

        if (shootPoint == null)
        {
            Debug.LogError("No se encontr� un objeto llamado 'Proyectil' dentro del enemigo.");
        }

        // Establecer el primer intervalo aleatorio
        ResetShootInterval();
    }

    void Update()
    {

        if (canShoot && shootPoint != null)
        {
            // Incrementar el temporizador
            shootTimer += Time.deltaTime;

            // Si el temporizador supera el intervalo, dispara
            if (shootTimer >= currentShootInterval)
            {
                Shoot();
                ResetShootInterval(); // Generar un nuevo intervalo aleatorio
                shootTimer = 0f; // Reiniciar el temporizador
            }
        }
    }

    private void Shoot()
    {
        if (projectilePrefab != null)
        {
            // Instanciar el proyectil en la posici�n del punto de disparo
            Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        }
    }

    private void ResetShootInterval()
    {
        // Generar un intervalo aleatorio entre los valores m�nimo y m�ximo
        currentShootInterval = Random.Range(minShootInterval, maxShootInterval);
    }
}

