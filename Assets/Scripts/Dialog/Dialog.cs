using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Sentence { string sentence; int skipPoint; }

[System.Serializable]
public class Dialog
{
    [Tooltip("화자")]
    public string name;

    [Tooltip("대사 내용")]
    public string[] contexts;
}

[System.Serializable]
public class DialogEvent
{
    public string name; // 이벤트명

    public Vector2 line;
    public Dialog[] dialogs;
}
