using UnityEngine;

public class MoverseMasRapido : MonoBehaviour
{
    public static MoverseMasRapido Instance;
    public ComportamientoJugador ComportamientoJugador;
    public float duracion = 10f; // Duración del efecto en segundos.
    public float multiplicadorVelocidad = 10;

    public bool moviendoseMasRapido = false;
    float timer = 0;
    /*private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantener el objeto al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Eliminar duplicados
        }
    }*/

    private void Start()
    {
        ComportamientoJugador = FindAnyObjectByType<ComportamientoJugador>();
    }


    private void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(Vector3.down * 0.01f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer = 0;
            moviendoseMasRapido = true;
            AumentarVelocidad();
            Destroy(gameObject); // Destruye el power-up después de usarlo.

            if (timer >= duracion)
            {
                DisminuirVelocidad();
                moviendoseMasRapido = false;

            }
        }

    }

    public void AumentarVelocidad()
    {
        ComportamientoJugador.velocidad += multiplicadorVelocidad;
    }
    public void DisminuirVelocidad()
    {
        ComportamientoJugador.velocidad -= multiplicadorVelocidad;
    }
}
