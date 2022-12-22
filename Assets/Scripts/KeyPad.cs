using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    public TMPro.TMP_Text ANS;
   public void number(int Number)
    {
        ANS.text += Number.ToString();
    }
}
