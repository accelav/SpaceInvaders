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

        if (gameObject.activeSelf == true)
        {
            GameManager.Instance.SaberVidaMaxima(vidaMaxima);
            
        }

    }


    //Sistema de seleccion de nave en el minijuego
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ProyectilJugador"))
        {
            
            if (esNaveUno) 
            {
                GameManager.Instance.SeleccionDeNave(0);
            }
            if (esNaveDos)
            {
                GameManager.Instance.SeleccionDeNave(1);
            }
            if (esNaveTres)
            {
                GameManager.Instance.SeleccionDeNave(2);
            }
            SceneManager.LoadScene("GameScene");
            Debug.Log("Ha Coisionado");
        }
    }


}
