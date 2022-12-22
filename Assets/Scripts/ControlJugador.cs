using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    private int hp = 10;
    public bool Perdio = false;
    public TMPro.TMP_Text textoGanaste;
    public TMPro.TMP_Text textoGameOver;
    public TMPro.TMP_Text textoRecolectados;
    public TMPro.TMP_Text TextoReincio;
    public TMPro.TMP_Text Energia;
    public bool PowerUp;
    int cont;
    public GameObject Enemigo;
    [Header("Muerto")]
    public GameObject Muerto;
    public GameObject ControlNumeros;

    public float velocidadActual;
    public float velocidadCaminando = 10;
    public float velocidadCorriendo = 15;
    public float energiaActual = 5;
    public bool agotado = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        velocidadActual = velocidadCaminando;

    }
    void Update()
    {
        float movimientoAdelanteAtras = Input.GetAxis("Vertical") * velocidadActual;
        float movimientoCostados = Input.GetAxis("Horizontal") * velocidadActual;
        movimientoAdelanteAtras *= Time.deltaTime;
        movimientoCostados *= Time.deltaTime;
        transform.Translate(movimientoCostados, 0, movimientoAdelanteAtras);
        int valorEnergia;
        valorEnergia =(int)energiaActual;
        Energia.text = "Energia:"+ valorEnergia.ToString();
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKey(KeyCode.LeftShift) && energiaActual > 0 && !agotado)
        {
            velocidadActual = velocidadCorriendo;
            energiaActual -= Time.deltaTime;       
        }
        else
        {
            if (energiaActual <= 0)
                agotado = true;

            velocidadActual = velocidadCaminando;
            if (energiaActual < 10)
            {
                energiaActual += Time.deltaTime; 
            }
            else
            {
                agotado = false;
            }       
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ControlNumeros.SetActive(!ControlNumeros.activeInHierarchy);
        }


    }
    public void setearTexto()
    {
        textoRecolectados.text = "Cantidad recolectados: " + cont.ToString();
        if (cont >= 3)
        {
            textoGanaste.text = "Ganaste!!";
            TextoReincio.text = "Presione R para reintentar";
        }
    }

    public void recibirDaño()
    {

        hp = hp - 10;

        if (hp <= 0)
        {
            hp = 0;
            Instantiate(Muerto);

            textoGameOver.text = " GAME  OVER!!!! ";
            TextoReincio.text = "Presione R para reintentar";
            Perdio = true;
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemigo") == true)
        {
            GestorDeAudio.instancia.ReproducirSonido("Grito");
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
            velocidadCorriendo += 5;
            velocidadCaminando += 5;
            other.gameObject.SetActive(false);
            StartCoroutine(Temporizador());
        }

    }
    IEnumerator Temporizador()
    {
        yield return new WaitForSeconds(8);
        PowerUp = false;
        velocidadCorriendo -= 5;
        velocidadCaminando -= 5;
    }
    IEnumerator EnergiaTemp()
    {
        yield return new WaitForSeconds(8);

    }
}
