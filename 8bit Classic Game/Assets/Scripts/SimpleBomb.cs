using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBomb : Bomb
{
    public override void explode()
    {
        Debug.Log("Explode!");
    }

    // Use this for initialization
    void Start ()
    {
        remainingTime = detonationTime;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (remainingTime <= 0) explode();
        else
        {
            remainingTime = remainingTime - Time.deltaTime;
        }
	}
}
