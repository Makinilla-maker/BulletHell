using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using MyBox;

public enum DialogeType
{
    NONE,
    SENTENCE,
    OPTIONS,
    END,
    ACTION,

}
[System.Serializable]
public class Dialoge
{
    public string name;


    public DialogeType type;
    [ConditionalField("type",false, DialogeType.OPTIONS)] public int a;
    [ConditionalField("type", false, DialogeType.ACTION)] public UnityEvent dialogeEvent;

    public float time;
    [TextArea(3,10)]
    public string sentences;
}
