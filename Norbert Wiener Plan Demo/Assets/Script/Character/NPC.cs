using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character
{
    // Cycle
    // Quests & Dialogues
    public DialougeData NPCDialouge;
    private bool isTalking;
    private bool known;

    public bool IsTalking { get => isTalking; set => isTalking = value; }

    void Start()
    {
        BindedObject = transform.gameObject;
        Name = transform.name;
        NPCDialouge = new DialougeData(Name);
        Debug.Log(Name + " Activated");
        IsTalking = false;
        known = false;
    }
}
