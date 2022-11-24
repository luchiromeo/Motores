using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirScreamer : MonoBehaviour
{
    public float tiempo;
    void Start()
    {
        Destroy(gameObject, tiempo);
    }

 
}
