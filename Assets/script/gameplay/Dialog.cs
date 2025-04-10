using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog
{
    [SerializeField] private List<string> lines;
    [SerializeField] public bool isFight;
    public List<string> Lines => lines;
}
