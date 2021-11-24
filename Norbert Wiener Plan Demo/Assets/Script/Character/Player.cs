using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    public Player()
    {
        BaseAttributes = new int[] { 1, 1, -4, 4 };
        Sharpness = new int[4];
    }
}
