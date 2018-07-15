using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    //Public Balancing Variables
    public float speed;
    public int maxBombs;
    public int bombRadius;
    public GameObject bombType;

    //Control Variables
    private bool alive;
    private bool victory;
    private bool invulnerable;
    private float invulnerableTime;

    //Riding Variables
    private bool riding;
    private bool jumping;
    private BoxCollider2D collider;
    private ExtraEgg extraEgg;

    //References
    private PlayerAnimation playerAnimation;
    private PlayerInput playerInput;

    private void Start()
    {
        extraEgg = null;
        jumping = false;
        riding = false;
        victory = false;
        alive = true;
        playerAnimation = this.GetComponent<PlayerAnimation>();
        playerInput = this.GetComponent<PlayerInput>();
        collider = this.GetComponent<BoxCollider2D>();
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

    //Check if Riding
    public bool isRiding()
    {
        return riding;
    }

    //Mount
    public void mount(Vector2 jumpTarget)
    {
        if (!riding)
        {
            this.transform.position = jumpTarget;
            riding = true;
            jumping = true;
            playerAnimation.mount();
            collider.enabled = false;
            playerInput.enabled = false;
            bombType = ControllerManager.Instance.bombController.pierceBomb;
        }
    }

    //Dismount
    public void dismount()
    {
        if(!jumping)
        {
            invulnerable = true;
            invulnerableTime = 1f;
            riding = false;
            jumping = true;
            collider.enabled = false;
            playerInput.enabled = false;
            bombType = ControllerManager.Instance.bombController.simpleBomb;
            if(ControllerManager.Instance.extraEggsController.extraEggsCount() > 0)
            {
                extraEgg = ControllerManager.Instance.extraEggsController.getNextEgg().GetComponent<ExtraEgg>();
                extraEgg.expendEgg(this.transform.position);
                bombType = ControllerManager.Instance.bombController.pierceBomb;
            }
            playerAnimation.dismount(extraEgg);
        }
    }

    //Player Death Method
    public void killPlayer()
    {
        if(!invulnerable)
        {
            if (alive)
            {
                if (riding)
                {
                    dismount();
                }
                else
                {
                    alive = false;
                    playerAnimation.setDeathAnimation();
                    playerInput.enabled = false;
                    LivesController.lives -= 1;
                }
            }
        }
    }

    //Victory
    public void setVictory()
    {
        if(!victory)
        {
            victory = true;
            playerInput.enabled = false;
            playerAnimation.setVictoryAnimation(riding);
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

        if(victory)
        {
            if(playerAnimation.isEndOfTeleportAnimation())
            {
                ControllerManager.Instance.sceneController.loadMainMenuScene();
                Destroy(this.gameObject);
            }
        }

        if(jumping)
        {
            playerAnimation.isEndOfDestroyAnimation();
            if (playerAnimation.isEndOfJumpingAnimation())
            {
                if (!riding)
                {
                    if (extraEgg != null)
                    {
                        extraEgg.destroyEgg(true);
                        playerAnimation.expendEgg();
                        riding = true;
                        extraEgg = null;
                    }
                    else
                    {
                        playerAnimation.disableMount();
                    }
                }

                jumping = false;
                collider.enabled = true;
                playerInput.enabled = true;
            }
        }
        else if(invulnerable)
        {
            invulnerableTime -= Time.deltaTime;
            playerAnimation.flashSprite(riding);
            if (invulnerableTime <= 0f)
            {
                playerAnimation.flashSpriteTerminal(riding);
                invulnerable = false;
            }
        }
    }
}
