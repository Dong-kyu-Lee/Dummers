using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Sentence { string sentence; int skipPoint; }

[System.Serializable]
public class Dialog
{
    [Tooltip("ȭ��")]
    public string name;

    [Tooltip("��� ����")]
    public string[] contexts;
}

[System.Serializable]
public class DialogEvent
{
    public string name; // �̺�Ʈ��

    public Vector2 line;
    public Dialog[] dialogs;
}
