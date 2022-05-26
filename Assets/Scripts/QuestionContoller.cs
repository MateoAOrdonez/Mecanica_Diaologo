using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionContoller : MonoBehaviour
{

    public Question question;
    [SerializeField] private TMP_Text questionText;
    public Button choiceButton;

    private List<ChoiceController> choiceControllers = new List<ChoiceController>();

    public void Change(Question _question)
    {
        RemoveChoices();
        question = _question;
        gameObject.SetActive(true);
        Initialize();
    }
    public void Hide(Conversation conversation)
    {
        RemoveChoices();
        gameObject.SetActive(false);
    }

    private void RemoveChoices()
    {
        foreach (ChoiceController c in choiceControllers)
            Destroy(c.gameObject);

        choiceControllers.Clear();
    }

    private void Start() { }

    private void Initialize()
    {
        questionText.text = question.Pregunta;

        for (int index = 0; index < question.opciones.Length; index++)
        {
            ChoiceController c = ChoiceController.AddChoiceButton(choiceButton, question.opciones[index], index);
            choiceControllers.Add(c);
        }

        choiceButton.gameObject.SetActive(false);
    }
}
