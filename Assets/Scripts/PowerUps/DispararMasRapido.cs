using UnityEngine;

public class DispararMasRapido : MonoBehaviour
{
    //public static DispararMasRapido Instance;
    public ComportamientoJugador ComportamientoJugador;
    public float duracion = 10f; // Duración del efecto en segundos.
    public bool estaDisparando;
    float timer;
    Vector3 movimiento = Vector3.down;
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
            estaDisparando = true;
            ComportamientoJugador.timer = 1;
            ComportamientoJugador.duracionTimer = 0.5f;
            Destroy(gameObject); // Destruye el power-up después de usarlo.

        }
        if (timer >= duracion)
        {
            estaDisparando = false;
            ComportamientoJugador.timer = 2;
            ComportamientoJugador.duracionTimer = 2;
            
        }
    }


}
