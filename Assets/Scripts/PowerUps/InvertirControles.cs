using UnityEngine;

public class InvertirControles : MonoBehaviour
{
    //public static InvertirControles Instance;
    public ComportamientoJugador ComportamientoJugador;
    public float duracion = 5f; // Duración del efecto en segundos.
    public bool estaInvirtiendo = false;
    public float timer = 0;
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
            estaInvirtiendo = true;
            ComportamientoJugador.velocidad = -ComportamientoJugador.velocidad;
            Destroy(gameObject); // Destruye el power-up después de usarlo.
        }

        if (timer >= duracion)
        {
            estaInvirtiendo = false;
            ComportamientoJugador.velocidad = +ComportamientoJugador.velocidad;
        }
    }

}


/* Copiar en script comportamientojugador
// Dentro del PlayerController
public bool controlsInverted = false;

void Update()
{
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");

    if (controlsInverted)
    {
        horizontal = -horizontal;
        vertical = -vertical;
    }

    // Movimiento del jugador basado en horizontal y vertical.
}
*/