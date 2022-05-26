using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConfiguracionDialogo : MonoBehaviour
{
    public Slider SliderVelocity;
    public Slider SliderTexto;
    public GameObject TMPDer;
    public GameObject TMPIzq;
    public TMP_FontAsset[] fuentes;
    public GameObject panelMenu;
    public GameObject panelTextoDer;
    public GameObject panelTextoIzq;
    private bool panelActivado;
    private int posicion;

    public float Altura;
    public float VelocidadTexto;
    public int TamañoTexto;
    public TMP_FontAsset fuente;

    // Start is called before the first frame update
    void Start()
    {
        panelTextoDer.GetComponent<RectTransform>().sizeDelta = new Vector2(0, Altura);
        panelTextoIzq.GetComponent<RectTransform>().sizeDelta = new Vector2(0, Altura);

        SliderVelocity.value = VelocidadTexto;
        SliderTexto.value = TamañoTexto;
        panelMenu.SetActive(false);
        panelActivado = false;
        posicion = 0;
        TMPDer.GetComponent<TMP_Text>().font = fuente;
        TMPIzq.GetComponent<TMP_Text>().font = fuente;
    }

    // Update is called once per frame
    void Update()
    {
        TMPDer.GetComponent<TMP_Text>().fontSize = SliderTexto.value;
        TMPIzq.GetComponent<TMP_Text>().fontSize = SliderTexto.value;

        Dialogue.velocidadEscritura = (SliderVelocity.value * 0.2f);

        if (Input.GetKeyDown(KeyCode.Escape) && panelActivado == false)
        {
            panelMenu.SetActive(true);
            panelActivado = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && panelActivado == true)
        {
            panelMenu.SetActive(false);
            panelActivado = false;
        }
        else
        {

        }

    }

    public void sumaFuente()
    {
        if (posicion < fuentes.Length-1)
        {
            posicion++;
            TMPDer.GetComponent<TMP_Text>().font = fuentes[posicion];
            TMPIzq.GetComponent<TMP_Text>().font = fuentes[posicion];
        }
    }

    public void restaFuente()
    {
        if (posicion < fuentes.Length && posicion != 0)
        {
            posicion--;
            TMPDer.GetComponent<TMP_Text>().font = fuentes[posicion];
            TMPIzq.GetComponent<TMP_Text>().font = fuentes[posicion];
        }
    }


}
