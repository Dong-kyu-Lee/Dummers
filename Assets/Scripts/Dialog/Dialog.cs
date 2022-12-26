using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Sentence
{
    private string sentence;
    public string Context { get => sentence; }
    private int skipPoint;
    public int SkipPoint { get => skipPoint; }

    public Sentence(string sen, int point)
    {
        sentence = sen;
        skipPoint = point;
    }
}

[System.Serializable]
public class Dialog
{
    [Tooltip("화자")]
    public string name;

    [Tooltip("대사 내용")]
    public Sentence[] contexts;
}
