using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomba : MonoBehaviour
{
    //private GameObject radioExplosion;
    //public Explosion Explosion;
    [SerializeField]
    GameObject prefabExplosion;
    GameObject explosion;
    public float velocidad = 2;
    float timer = 0;
    bool tiempo = false;
    public bool explotar = false;
    void Start()
    {
        //radioExplosion = GameObject.FindGameObjectWithTag("Explosion");
        if (explosion != null)
        {
            Destroy(explosion);
        }


    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * velocidad * Time.deltaTime);

        if (explotar)
        {
           


        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemigo"))
        {
            explosion = Instantiate(prefabExplosion, other.gameObject.transform.position, Quaternion.identity);
            explosion.SetActive(true);
            //Destroy(gameObject);
            //explotar = true;
            
        }

    }
}
