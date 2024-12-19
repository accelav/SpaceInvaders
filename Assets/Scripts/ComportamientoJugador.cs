using UnityEngine;
using UnityEngine.SceneManagement;

public class ComportamientoJugador : MonoBehaviour
{
    public float velocidad = 10f; // Velocidad de movimiento
    public float screenLimit = 8f; // Límite horizontal del movimiento
    public bool esNaveUno = false;
    public bool esNaveDos = false;
    public bool esNaveTres = false;
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
       
    }


    //Sistema de seleccion de nave en el minijuego
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ProyectilJugador")
        {
            if (esNaveUno) 
            {
                GameManager.Instance.seleccionDeNave(0);
            }
            if (esNaveDos)
            {
                GameManager.Instance.seleccionDeNave(1);
            }
            if (esNaveTres)
            {
                GameManager.Instance.seleccionDeNave(2);
            }

        }
    }


}
