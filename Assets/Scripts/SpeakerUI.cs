using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeakerUI : MonoBehaviour
{

    public Image retrato;
    [SerializeField] private TMP_Text nombre;
    [SerializeField] private TMP_Text dialogo;

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
