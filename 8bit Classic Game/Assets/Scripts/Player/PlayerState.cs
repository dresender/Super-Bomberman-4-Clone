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
    private bool alive;
    private bool victory;

    //References
    private PlayerAnimation playerAnimation;
    private PlayerInput playerInput;

    private void Start()
    {
        victory = false;
        alive = true;
        playerAnimation = this.GetComponent<PlayerAnimation>();
        playerInput = this.GetComponent<PlayerInput>();
    }

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
        if(alive)
        {
            alive = false;
            playerAnimation.setDeathAnimation();
            playerInput.enabled = false;
            LivesController.lives -= 1;
        }
    }

    //Victory
    public void setVictory()
    {
        if(!victory)
        {
            victory = true;
            playerInput.enabled = false;
            playerAnimation.setVictoryAnimation();
        }
    }

    //Update Method
    private void Update()
    {
        if(!alive)
        {
            if (playerAnimation.isEndOfDeathAnimation())
            {
                ControllerManager.Instance.sceneController.reloadScene();
                Destroy(this.gameObject);
            }
        }
        else if(victory)
        {
            if(playerAnimation.isEndOfTeleportAnimation())
            {
                ControllerManager.Instance.sceneController.loadMainMenuScene();
                Destroy(this.gameObject);
            }
        }
    }
}
