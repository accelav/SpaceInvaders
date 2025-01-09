using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComportamientoJugador : MonoBehaviour
{
    public float velocidad = 10f; // Velocidad de movimiento
    public float screenLimit = 8f; // Límite horizontal del movimiento
    public bool esNaveUno = false;
    public bool esNaveDos = false;
    public bool esNaveTres = false;
    public int vidaMaxima = 3;
    public int vidaActual;

    public bool aumentoVelocidad = false;
    public int numeroDeNave = 0;

    [SerializeField]
    GameObject proyectilJugador;

    GameObject proyectil;

    [SerializeField]
    GameObject prefabBomba;

    GameObject bomba;
    [SerializeField]
    GameObject prefabExplosion;
    GameObject explosion;

    public float timer = 2;
    public float duracionTimer = 1;
    public float timer2 = 0;
    public float tiempoBomba = 10;
    private void Start()
    {

        GameManager.Instance.SaberVidaMaxima(vidaMaxima);

    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Minijuego")
        {

        }
        else
        {
            float input = Input.GetAxisRaw("Horizontal");
            transform.Translate(Vector3.right * input * velocidad * Time.deltaTime);
            float clampedX = Mathf.Clamp(transform.position.x, -screenLimit, screenLimit);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }

        timer += Time.deltaTime;
        timer2 += Time.deltaTime;

        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                if (timer >= duracionTimer)
                {
                    proyectil = Instantiate(proyectilJugador, gameObject.transform.position, Quaternion.identity);
                    
                    timer = 0;
                }

                
            }
            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.JoystickButton2))
            {
                if (timer2 >= tiempoBomba)
                {
                    Debug.Log("Lanzando Bomba");
                    bomba = Instantiate(prefabBomba, gameObject.transform.position, Quaternion.identity);
                    
                }
            }
        }

    }


    //Sistema de seleccion de nave en el minijuego
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ProyectilJugador"))
        {
            GameManager.Instance.SeleccionDeNave(numeroDeNave);
            Debug.Log("Funciona");
        }
        if (other.gameObject.CompareTag("Proyectil"))
        {
            GameManager.Instance.GestionarVidas(1);
            Debug.Log("Menos una vida");
        }
    }


}
