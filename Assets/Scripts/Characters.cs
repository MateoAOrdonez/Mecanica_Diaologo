using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Nuevo personaje", menuName = "Personaje")]
public class Characters : ScriptableObject
{
    public string nombrePersonaje;
    public Sprite imgPersonaje;
}
