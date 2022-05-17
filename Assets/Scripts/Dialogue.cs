using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField, TextArea(4,6)] private string[] lineasDeDialogo;
    [SerializeField] private GameObject PanelDelDialogo;
    [SerializeField] private TMP_Text CajaDeDialogo;

    private bool didDialogueStart;
    private int lineIndex;
    public float velocidadEscritura;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (CajaDeDialogo.text == lineasDeDialogo[lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                CajaDeDialogo.text = lineasDeDialogo[lineIndex];
            }
        }
        

            

    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        PanelDelDialogo.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if(lineIndex < lineasDeDialogo.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            PanelDelDialogo.SetActive(false);
        }
    }

    private IEnumerator ShowLine()
    {
        CajaDeDialogo.text = string.Empty;

        foreach(char ch in lineasDeDialogo[lineIndex])
        {
            CajaDeDialogo.text += ch;
            yield return new WaitForSeconds(velocidadEscritura);
        }
    }
}
