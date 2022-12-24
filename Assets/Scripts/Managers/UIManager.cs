using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public GameObject interactionUI;
    public Vector2 interactionUIPos;
    public Vector2 dialoguePosition;

    void Start()
    {
        dialogueUI = Instantiate(dialogueUI, dialoguePosition, Quaternion.identity, 
            GameObject.Find("Canvas").transform);
        dialogueUI.SetActive(false);
    }

    void Update()
    {
        
    }

    public void CreateInteraction()
    {
        Instantiate(interactionUI, interactionUIPos, Quaternion.identity, GameObject.Find("Canvas").transform);
    }



    public void OpenDialogue()
    {
        dialogueUI.SetActive(true);
    }
    public void CloseDialogue()
    {
        dialogueUI.SetActive(false);
    }

    public void ChangeDialogText(string newText)
    {
        dialogueUI.GetComponent<Text>().text = newText;
    }
}
