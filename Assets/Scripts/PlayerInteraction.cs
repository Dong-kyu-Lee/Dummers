using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    bool isInteractable;
    bool isTalking;
    int currentTextIndex = 0;
    GameObject interactableObj;
    List<Sentence> textList = new List<Sentence>();

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

    public void OperateDialogList()
    {
        Debug.Log(textList.Count);
        if (textList.Count != 0)
        {
            if (currentTextIndex < textList.Count)
            {
                GameManager.UI.ChangeDialogText(textList[currentTextIndex].Context);
                ++currentTextIndex;
            }
            else
            {
                GameManager.UI.CloseDialogue();
                currentTextIndex = 0;
                textList.Clear();
                isTalking = false;
            }
        }
    }

    public void InteractWithNPC()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isInteractable && isTalking == false)
            {
                if (textList.Count != 0) textList.Clear();
                Dialog[] dialogs = interactableObj.transform.GetComponent<InteractionEvent>().GetDialogs();
                if (dialogs != null)
                {
                    for (int i = 0; i < dialogs.Length; ++i)
                    {
                        for (int j = 0; j < dialogs[i].contexts.Length; ++j)
                            textList.Add(dialogs[i].contexts[j]);
                    }
                }
                GameManager.UI.OpenDialogue();
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
            interactableObj = collision.gameObject;
        }
    }
}
