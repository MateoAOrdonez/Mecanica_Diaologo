using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConfiguracionDialogo : MonoBehaviour
{
    public Slider SliderVelocity;
    public Slider SliderTexto;
    public GameObject TMP;
    [SerializeField] public TMP_FontAsset[] fuentes;
    public GameObject panelMenu;
    public GameObject panelTexto;
    private bool panelActivado;
    private int posicion;

    public float Altura;
    public float VelocidadTexto;
    public int TamañoTexto;
    public TMP_FontAsset fuente;

    // Start is called before the first frame update
    void Start()
    {
        panelTexto.GetComponent<RectTransform>().sizeDelta = new Vector2(0, Altura);

        SliderVelocity.value = VelocidadTexto;
        SliderTexto.value = TamañoTexto;
        panelMenu.SetActive(false);
        panelActivado = false;
        posicion = 0;
        TMP.GetComponent<TMP_Text>().font = fuente;
    }

    // Update is called once per frame
    void Update()
    {
        TMP.GetComponent<TMP_Text>().fontSize = SliderTexto.value;

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
            TMP.GetComponent<TMP_Text>().font = fuentes[posicion];
        }
    }

    public void restaFuente()
    {
        if (posicion < fuentes.Length && posicion != 0)
        {
            posicion--;
            TMP.GetComponent<TMP_Text>().font = fuentes[posicion];
        }
    }


}
