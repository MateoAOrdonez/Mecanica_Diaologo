using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Line
{
    //public string TituloDelDialogo;
    public Characters personaje;

    [TextArea(2, 5)]
    public string dialogo;
}

[CreateAssetMenu (fileName = "Nueva conversación", menuName = "Conversación")]
public class Conversation : ScriptableObject
{
    public Characters personajeIzquierdo;
    public Characters personajeDerecho;
    public Line[] lineasDeDialogo;
    public Question decision;
    public Conversation siguienteConversacion;
}
