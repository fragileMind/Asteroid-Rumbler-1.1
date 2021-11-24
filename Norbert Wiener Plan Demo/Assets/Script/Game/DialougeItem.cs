using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeItem
{
    protected string itemID;
    protected string content;
    public string ItemID { get => itemID; }
    public string Content { get => content; set => content = value; }
}
public class QuestionItem : DialougeItem
{
    string otherNPC;
    List<AnswerItem> answers;

    public string OtherNPC { get => otherNPC; set => otherNPC = value; }
    public List<AnswerItem> Answers { get => answers; set => answers = value; }

    public QuestionItem(string id, string allContent, string other=null)
    {
        itemID = id;
        Content = allContent;
        Answers = new List<AnswerItem>();
        OtherNPC = other;
    }
}

public class AnswerItem : DialougeItem
{
    bool check;
    string tag;
    string next;

    public bool Check { get => check; set => check = value; }
    public string Tag { get => tag; set => tag = value; }
    public string Next { get => next; set => next = value; }

    public AnswerItem(string id, string allContent, string nextQue, bool checkCondition=true, string addTag = null)
    {
        itemID = id;
        Content = allContent;
        next = nextQue;
        check = checkCondition;
        tag = addTag;
    }
}