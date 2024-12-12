using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfazPausa : MonoBehaviour
{
    public void RegresarAtras()
    {
        SceneController.Instance.TogglePause();
    }
}