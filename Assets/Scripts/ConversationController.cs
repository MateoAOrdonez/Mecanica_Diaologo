using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class QuestionEvent : UnityEvent<Question> { }

public class ConversationController : MonoBehaviour
{
    public GameObject Instruccion;

    public Conversation conversation;
    public Conversation defaultConversation;
    public QuestionEvent questionEvent;

    public static bool didDialogueStart;
    public static float velocidadEscritura;
    public static bool endDialo;

    public GameObject PersonajeIzquierda;
    public GameObject PersonajeDerecha;

    private SpeakerUI hablanteUiIzquierda;
    private SpeakerUI hablanteUiDerecha;

    private string dialogoConversation;

    private int lineIndex;
    private bool conversationStarted = false;

    public void ChangeConversation(Conversation nextConversation)
    {
        conversationStarted = false;
        conversation = nextConversation;
        lineIndex = 0;
        NextDialogueLine();
    }

    // Start is called before the first frame update
    void Start()
    {
        hablanteUiIzquierda = PersonajeIzquierda.GetComponent<SpeakerUI>();
        hablanteUiDerecha = PersonajeDerecha.GetComponent<SpeakerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (lineIndex < conversation.lineasDeDialogo.Length)
        {
            Line line = conversation.lineasDeDialogo[lineIndex];
            dialogoConversation = line.dialogo;
        }

        //Debug.Log(OnTriggerEnter.onTrigger);
        if (OnTriggerEnter.onTrigger == true && endDialo == false)
        {
            
            if (!didDialogueStart && (Input.GetKeyDown(KeyCode.E)))
            {
                StartDialogue();
                Debug.Log(lineIndex);
                lineIndex++;
                //Debug.Log(SpeakerUI.dialogo.text);
            }

            if (didDialogueStart && Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log(lineIndex);
                //Debug.Log(SpeakerUI.DialogoCompleto);

                //if (SpeakerUI.dialogo.text == dialogoConversation)
                //{
                NextDialogueLine();

                //}
                //else
                //{
                   // Debug.Log("Esperar");
//}

                //NextDialogueLine();
            }
        }
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        lineIndex = 0;
        hablanteUiIzquierda.Hablante = conversation.personajeIzquierdo;
        hablanteUiDerecha.Hablante = conversation.personajeDerecho;
        DisplayLine();
        Instruccion.SetActive(false);
        conversationStarted = false;
    }

    private void NextDialogueLine()
    {
        if (lineIndex < conversation.lineasDeDialogo.Length)
        {
            DisplayLine();
            endDialo = false;
        }
        else
        {
            AdvanceConversation();
        }

        lineIndex++;
    }

    private void DisplayLine()
    {
        Line line = conversation.lineasDeDialogo[lineIndex];
        Characters characters = line.personaje;

        if (hablanteUiIzquierda.SpeakerIs(characters))
        {
            SetDialog(hablanteUiIzquierda, hablanteUiDerecha, line);
        }
        else
        {
            SetDialog(hablanteUiDerecha, hablanteUiIzquierda, line);
        }
    }

    public void SetDialog
        (
            SpeakerUI activeSpeakerUI,
            SpeakerUI inactiveSpeakerUI,
            Line line
        )
    {
        
        activeSpeakerUI.Show();
        inactiveSpeakerUI.Hide();

        activeSpeakerUI.Dialog = "";


        StopAllCoroutines();
        StartCoroutine(EffectTypewriter(line.dialogo, activeSpeakerUI));
    }

    private void AdvanceConversation()
    {
        if (conversation.decision !=null)
        {
            questionEvent.Invoke(conversation.decision);
            Debug.Log("decision");
        }
            
        else if(conversation.siguienteConversacion != null)
        {
            ChangeConversation(conversation.siguienteConversacion);
            Debug.Log("Sigue");
        }
        else
        {
            EndConversation();
            Debug.Log("3");
        }

    }

    private IEnumerator EffectTypewriter(string text, SpeakerUI speedText)
    {
        foreach (char character in text.ToCharArray())
        {
            speedText.Dialog += character;
            yield return new WaitForSeconds(velocidadEscritura);
        }
    }

    private void EndConversation()
    {
        conversation = defaultConversation;
        conversationStarted = false;
        hablanteUiIzquierda.Hide();
        hablanteUiDerecha.Hide();
        didDialogueStart = false;
    }
}
