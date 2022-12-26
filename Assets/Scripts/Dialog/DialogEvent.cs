using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueEvent", menuName = "DialogueEvent/DialogueEvent")]
public class DialogEvent : ScriptableObject
{
    public string fileName; // �̺�Ʈ��

    public Vector2 line;
    public Dialog[] dialogs;
}

