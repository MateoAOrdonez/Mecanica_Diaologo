using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeakerUI : MonoBehaviour
{

    public Image retrato;
    public TMP_Text nombre;
    public TMP_Text dialogo;

    private Characters hablante;
    public Characters Hablante
    {
        get { return hablante; }
        set
        {
            hablante = value;
            retrato.sprite = hablante.imgPersonaje;
            nombre.text = hablante.nombrePersonaje;
        }
    }
    public string Dialog
    {
        get { return dialogo.text; }
        set { dialogo.text = value; }
    }

    public bool HasSpeaker()
    {
        return hablante != null;
    }

    public bool SpeakerIs(Characters characters)
    {
        return hablante == characters;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
