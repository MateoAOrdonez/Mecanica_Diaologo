using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

[System.Serializable]
public class ConversationChangeEvent : UnityEvent<Conversation> { }

public class ChoiceController : MonoBehaviour
{
    public Opcion opcion;
    public ConversationChangeEvent conversationChangeEvent;

    public static ChoiceController AddChoiceButton(Button choiceButtonTemplate, Opcion opcion, int index)
    {
        int buttonSpacing = -100;
        Button button = Instantiate(choiceButtonTemplate);

        button.transform.SetParent(choiceButtonTemplate.transform.parent);
        button.transform.localScale = Vector3.one;
        button.transform.localPosition = new Vector3(0, index * buttonSpacing, 0);
        button.name = "Choice " + (index + 1);
        button.gameObject.SetActive(true);

        ChoiceController choiceController = button.GetComponent<ChoiceController>();
        choiceController.opcion = opcion;
        return choiceController;
    }

    private void Start()
    {
        if (conversationChangeEvent == null)
            conversationChangeEvent = new ConversationChangeEvent();

        GetComponent<Button>().GetComponentInChildren<TMP_Text>().text = opcion.Texto;
    }

    public void MakeChoice()
    {
        conversationChangeEvent.Invoke(opcion.Respuesta);
    }
}
