using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Opcion
{
    [TextArea(2, 5)]
    public string Texto;
    public Conversation Respuesta;
}

[CreateAssetMenu(fileName = "Nueva decision", menuName = "Decision")]
public class Question : ScriptableObject
{
    [TextArea(2, 5)]
    public string Pregunta;
    public Opcion[] opciones;
}
