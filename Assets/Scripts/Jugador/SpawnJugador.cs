using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnJugador : MonoBehaviour
{
    [SerializeField]
    GameObject[] naves;

    GameObject naveSeleccionada;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            InstanciarNaves();
            Debug.Log("GameScene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstanciarNaves()
    {
        naveSeleccionada = Instantiate(naves[GameManager.Instance.naveInstanciar], new Vector3(0,-4,0), Quaternion.identity);
    }

}
