using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnter : MonoBehaviour
{

    public GameObject textoInstru;
    public static bool onTrigger;

    // Start is called before the first frame update
    void Start()
    {
        textoInstru.SetActive(false);
        onTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.name.Equals("Player") )
        {
            textoInstru.SetActive(true);
            onTrigger = true;
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            textoInstru.SetActive(false);
            onTrigger = false;
            ConversationController.endDialo = false;
        }
    }

}
