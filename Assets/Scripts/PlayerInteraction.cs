using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    bool isInteractable;
    bool isTalking;
    Dialog[] dialogs;
    void Start()
    {
        isInteractable = false;
        isTalking = false;
        GameManager.Input.keyAction -= InteractWithNPC;
        GameManager.Input.keyAction += InteractWithNPC;
    }

    void Update()
    {
        
    }

    public void InteractWithNPC()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isInteractable && isTalking == false)
            {
                GameManager.UI.OpenDialogue();
                //GameManager.UI.ChangeDialogText(dialogs);
                isTalking = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("NPC"))
        {
            Debug.Log("Detected");
            isInteractable = true;
            dialogs = collision.transform.GetComponent<InteractionEvent>().GetDialogs();
            /*for(int i = 0; i < dialogs.Length; ++i)
            {
                for (int j = 0; j < dialogs[i].contexts.Length; ++j)
                    Debug.Log(dialogs[i].contexts[j].Context);
            }*/
        }
    }
}
