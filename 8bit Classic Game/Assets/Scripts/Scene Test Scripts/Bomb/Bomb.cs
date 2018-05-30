﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class Bomb : MonoBehaviour
{
    //Generic Bomb Variables
    protected Animator animator;
    protected int radius = 1;
    protected float animDuration = 2.5f;  //(2.5s)
    protected float elapsedTime = 0;      //(Used in Update)

    //Explosions Prefabs
    public GameObject centerExplosion;
    public GameObject rightArmExplosion;
    public GameObject rightEndExplosion;
    public GameObject leftArmExplosion;
    public GameObject leftEndExplosion;
    public GameObject upArmExplosion;
    public GameObject upEndExplosion;
    public GameObject downArmExplosion;
    public GameObject downEndExplosion;

    //Explode Method for Bomb (vary according to Bomb Type)
    public abstract void explode();
}
