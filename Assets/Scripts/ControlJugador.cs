using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    public float rapidez;
    private int hp = 10;
    public bool Perdio = false;
    public TMPro.TMP_Text textoGanaste;
    public TMPro.TMP_Text textoGameOver;
    public TMPro.TMP_Text textoRecolectados;
    public GameObject Enemigo;
    public bool PowerUp;
    int cont;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float movimientoAdelanteAtras = Input.GetAxis("Vertical") * rapidez;
        float movimientoCostados = Input.GetAxis("Horizontal") * rapidez;
        movimientoAdelanteAtras *= Time.deltaTime;
        movimientoCostados *= Time.deltaTime;
        transform.Translate(movimientoCostados, 0, movimientoAdelanteAtras);
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void setearTexto()
    {
        textoRecolectados.text = "Cantidad recolectados: " + cont.ToString();
        if (cont >= 3)
        {
            textoGanaste.text = "Ganaste!!";
        }
    }

    public void recibirDaño()
    {

        hp = hp - 10;

        if (hp <= 0)
        {
            hp = 0;

            textoGameOver.text = " GAME  OVER!!!! ";
            Perdio = true;
            

        }
    }
   

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemigo")==true)
        {
            recibirDaño();
        }
        if (other.gameObject.CompareTag("Coleccionable") == true)
        {
            cont = cont + 1;
            setearTexto();  
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("AumentoDeRapidez") == true)
        {
            PowerUp = true;
            rapidez+=2;
            other.gameObject.SetActive(false);
            StartCoroutine(Temporizador());
        }

    }
    IEnumerator Temporizador()
    {
        yield return new WaitForSeconds(8);
        PowerUp = false;
        rapidez -= 2;
    }

    
}
