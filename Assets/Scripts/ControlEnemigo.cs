using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigo : MonoBehaviour
{
    private GameObject Jugador;
    public int rapidez;
    void Start()
    {
        Jugador = GameObject.Find("Jugador");
    }

    void Update()
    {
        transform.LookAt(Jugador.transform);
        transform.Translate( rapidez * Vector3.forward * Time.deltaTime); 
    }
    
}
