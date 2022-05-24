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
    [SerializeField] public TextMeshProUGUI[] lineasDeDialogo;
    public GameObject panel;
    private bool panelActivado;

    // Start is called before the first frame update
    void Start()
    {
        SliderVelocity.value = 0.6f;
        SliderVelocity.value = 100f;
        panel.SetActive(false);
        panelActivado = false;
    }

    // Update is called once per frame
    void Update()
    {
        TMP.GetComponent<TMP_Text>().fontSize = SliderTexto.value;
        Debug.LogError(TMP.GetComponent<TMP_Text>().font);

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
    }


}
