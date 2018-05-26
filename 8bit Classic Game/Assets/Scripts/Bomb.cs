using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bomb : MonoBehaviour
{
    //Generic Bomb Variables
    protected int radius = 1;
    protected float detonationTime = 2.5f;  //(2.5s)
    protected float remainingTime = 0;      //(Used in Update)

    //Explode Method for Bomb (vary according to Bomb Type)
    public abstract void explode();
}
