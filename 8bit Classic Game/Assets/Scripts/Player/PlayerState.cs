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

    //References
    private PlayerAnimation playerAnimation;
    private PlayerInput playerInput;

    private void Start()
    {
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
            LivesController.Instance.lives -= 1;
        }
    }

    //Update Method
    private void Update()
    {
        if(!alive)
        {
            if (playerAnimation.getStateAnimation() >= 1f)
            {
                ControllerManager.Instance.sceneController.reloadScene();
                Destroy(this.gameObject);
            }
        }
    }
}
