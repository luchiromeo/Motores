using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    public TMPro.TMP_Text ANS;
    private string Answer = "12345";
   public void number(int Number)
    {
        ANS.text += Number.ToString();
    } 

    public void Ejecutar()
    {

        if (ANS.text == Answer)
        {
            ANS.text = "OPEN";
        }
        else
        {
            ANS.text = "Incorrecto";
        }
    }
}
