using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bomb
{
    //Generic Bomb Variables
    int radius;

    //Explode Method for Bomb (vary according to Bomb Type)
    public abstract void explode();
}
