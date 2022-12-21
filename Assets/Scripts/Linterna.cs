using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Linterna : MonoBehaviour
{
    public Light luzLinterna;
    public bool activLight;
    public float cantBateria=100;
    public float PerdidaBat = 0.5f;
    public Text porcentaje;

    void Update()
    {
        
        cantBateria= Mathf.Clamp(cantBateria,0,100);
        int ValorBat = (int)cantBateria;
        porcentaje.text = ValorBat.ToString() + "%";
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            activLight = !activLight;

            if (activLight == true)
            {
                luzLinterna.enabled = true;
            }

            if (activLight == false)
            {
                luzLinterna.enabled = false;
            }
        }

        if (activLight == true && cantBateria > 0) //reduce la bateria
        {
            cantBateria -=PerdidaBat * Time.deltaTime;
        }

        if (cantBateria > 0 && cantBateria < 50)
        {
            luzLinterna.intensity = 15f;
        }

        if (cantBateria > 0 && cantBateria < 25)
        {
            luzLinterna.intensity = 10f;
        }

        if (cantBateria == 0)
        {
            luzLinterna.intensity = 0f;

        }
    }
}
