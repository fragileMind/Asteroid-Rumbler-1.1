using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public string characterName;
    private int[] baseAttributes;
    private int[] sharpness;
    private int mood;
    private GameObject bindedObject;

    public string Name { get => characterName; set => characterName = value; }
    public int[] BaseAttributes { get => baseAttributes; set => baseAttributes = value; }
    public int[] Sharpness { get => sharpness; set => sharpness = value; }
    public int Mood { get => mood; set => mood = value; }
    protected GameObject BindedObject { get => bindedObject; set => bindedObject = value; }

    public Character()
    {
        BaseAttributes = new int[4];
    }

    public int getAttr(Attr chose)
    {
        return BaseAttributes[(int)chose];
    }

    public void ApplyAttr(Attr affected, int value)
    {
        BaseAttributes[(int)affected] += value;
    }

    public void AddSharp(Attr affected, int value)
    {
        Sharpness[(int)affected] += value;
    }

    public void ApplySharp(int attrID, bool apply)
    {
        if (apply)
        {
            baseAttributes[attrID] += Sharpness[attrID];
        }
    }
}