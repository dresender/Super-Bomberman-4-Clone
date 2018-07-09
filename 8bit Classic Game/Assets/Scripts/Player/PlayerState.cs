using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    //Public Variables
    public float speed;
    public int maxBombs;
    public int bombRadius;
    public GameObject bombType;

    //Singleton Instance Variable
    private static PlayerState instance;
    public static PlayerState Instance
    {
        get
        {
            return instance;
        }
    }

    //On Object Awake
    private void Awake()
    {
        //Check Singleton
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    //On Object Destroy (Safeguard)
    public void OnDestroy()
    {
        instance = null;
    }

    //Player Death Method
    public void killPlayer()
    {
        //TODO
        Debug.Log("Player Killed!");
    }
}
