using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start() 
    { 
        
    }
    void Update()
    { 
      
        if (Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            GestorDeAudio.instancia.ReproducirSonido("Pasos");
        }
    }
}
