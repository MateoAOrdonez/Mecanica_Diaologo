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

    // Start is called before the first frame update
    void Start()
    {
        SliderVelocity.value = 0.6f;
        SliderVelocity.value = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        TMP.GetComponent<TMP_Text>().fontSize = SliderTexto.value;

        Dialogue.velocidadEscritura = (SliderVelocity.value * 0.2f);

    }


}
