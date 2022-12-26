using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueEvent", menuName = "DialogueEvent/DialogueEvent")]
public class DialogEvent : ScriptableObject
{
    public string fileName; // 이벤트명

    public Vector2 line;
    public Dialog[] dialogs;
}

