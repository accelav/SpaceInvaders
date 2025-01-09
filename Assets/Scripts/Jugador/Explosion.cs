using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    GameObject bomba;
    public float velocidad = 2;
    void Start()
    {
        //Bomba = FindAnyObjectByType<Bomba>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * velocidad * Time.deltaTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemigo"))
        {

            Destroy(gameObject);
            Destroy(bomba);
        }
    }
}
