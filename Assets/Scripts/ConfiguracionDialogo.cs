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
    public GameObject panel;
    private bool panelActivado;
    private int posicion;
    public Dropdown drop;

    // Start is called before the first frame update
    void Start()
    {
        SliderVelocity.value = 0.6f;
        SliderVelocity.value = 100f;
        panel.SetActive(false);
        panelActivado = false;
        posicion = 0;
        TMP.GetComponent<TMP_Text>().font = fuentes[posicion];

        drop.options.Clear();


        for (int i = 0; i < fuentes.Length; i++)
        {
            drop.options.Add(new Dropdown.OptionData() { text = fuentes[i].name });
        }

        drop.onValueChanged.AddListener(delegate {
            DropdownValueChanged(drop);
        });
    }

    void DropdownValueChanged(Dropdown change)
    {
        Debug.Log("este escogio: " + change.value);
        TMP.GetComponent<TMP_Text>().font = fuentes[change.value];
    }

    // Update is called once per frame
    void Update()
    {
        TMP.GetComponent<TMP_Text>().fontSize = SliderTexto.value;

        Dialogue.velocidadEscritura = (SliderVelocity.value * 0.2f);

        if (Input.GetKeyDown(KeyCode.Escape) && panelActivado == false)
        {
            panel.SetActive(true);
            panelActivado = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && panelActivado == true)
        {
            panel.SetActive(false);
            panelActivado = false;
        }
        else
        {

        }

        Debug.Log(fuentes[posicion].name);

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
