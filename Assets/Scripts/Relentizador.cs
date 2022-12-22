using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relentizador : MonoBehaviour
{
    public GameObject Enemigo;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Jugador")
        {
            Enemigo.GetComponent<ControlEnemigo>().rapidezEnemigo -= 2;
            Destroy(gameObject);
            StartCoroutine(RelentizadorTemp());

        }

    }
    IEnumerator RelentizadorTemp()
    {
        yield return new WaitForSeconds(10);
        Enemigo.GetComponent<ControlEnemigo>().rapidezEnemigo += 2;
    }

}
