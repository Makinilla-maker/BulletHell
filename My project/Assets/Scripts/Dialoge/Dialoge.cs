using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialoge
{
    public string name;

    public float time;
    [TextArea(3,10)]
    public string sentences;
}
