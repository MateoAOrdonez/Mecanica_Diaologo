using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField, TextArea(4, 6)] private string[] lineasDeDialogo;
    [SerializeField] private GameObject PanelDelDialogo;
    [SerializeField] private TMP_Text CajaDeDialogo;

    public static bool didDialogueStart;
    private int lineIndex;
    public static float velocidadEscritura;
    public static bool endDialo;

    // Start is called before the first frame update
    void Start()
    {
        endDialo = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (OnTriggerEnter.onTrigger == true && endDialo == false)
        {
            if (!didDialogueStart && (Input.GetKeyDown(KeyCode.E)))
            {
                StartDialogue();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {

                if (CajaDeDialogo.text == lineasDeDialogo[lineIndex])
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

    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        PanelDelDialogo.SetActive(true);
        lineIndex = 0;
        endDialo = false;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < lineasDeDialogo.Length)
        {
            StartCoroutine(ShowLine());
            endDialo = false;
        }
        else
        {
            didDialogueStart = false;
            PanelDelDialogo.SetActive(false);
            endDialo = true;
        }
    }

    private IEnumerator ShowLine()
    {
        CajaDeDialogo.text = string.Empty;

        foreach (char ch in lineasDeDialogo[lineIndex])
        {
            CajaDeDialogo.text += ch;
            yield return new WaitForSeconds(velocidadEscritura);
        }
    }
}