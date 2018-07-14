using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //Variables
    private SpriteRenderer bombermanSpriteRenderer;
    private Animator bombermanAnimator;
    private Animator mountAnimator;
    private MountLayerController mountLayerController;
    private GameObject mountObject;
    private float flashSpriteInterval;
    private AudioManager aManager;

    // Use this for initialization
    void Start ()
    {
        //Cacheing the Audio Manager in the local variable
        aManager = FindObjectOfType<AudioManager>();

        bombermanAnimator = this.transform.GetChild(0).GetComponent<Animator>();
        bombermanSpriteRenderer = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        mountAnimator = this.transform.GetChild(1).GetComponent<Animator>();
        mountLayerController = this.transform.GetChild(1).GetComponent<MountLayerController>();
        mountObject = this.transform.GetChild(1).gameObject;
        mountObject.SetActive(false);
        flashSpriteInterval = 0f;
    }

    //Set Movement Animation
    public void setMovementAnimation(bool moving, int direction, bool riding)
    {
        bombermanAnimator.SetInteger("Direction", direction);
        bombermanAnimator.SetBool("Moving", moving);
        if (riding)
        {
            mountAnimator.SetInteger("Direction", direction);
            if (direction == 0) mountLayerController.setDownMovement(true);
            else mountLayerController.setDownMovement(false);
        }
        if (riding) mountAnimator.SetBool("Moving", moving);
    }

    //Set Movement Animation
    public void setMovementAnimation(bool moving, bool riding)
    {
        bombermanAnimator.SetBool("Moving", moving);
        if (riding) mountAnimator.SetBool("Moving", moving);
    }

    //get State Animation
    public bool isEndOfDeathAnimation()
    {
        if (bombermanAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Death"))
        {
            return bombermanAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f;
        }
        else return false;
    }

    //get State Animation
    public bool isEndOfJumpingAnimation()
    {
        if (bombermanAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Jumping"))
        {
            if (bombermanAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                bombermanAnimator.SetTrigger("EndJump");
                return true;
            }
            else return false;
        }
        else return false;
    }

    //Disable Mount
    public void disableMount()
    {
        mountObject.SetActive(false);
    }

    //Set Death Animation
    public void setDeathAnimation()
    {
        bombermanAnimator.SetTrigger("Kill");
    }

    //Dismount
    public void dismount()
    {
        aManager.Play("Dismount");
        bombermanAnimator.SetBool("Riding", false);
        bombermanAnimator.ResetTrigger("EndJump");
        bombermanAnimator.SetTrigger("JumpOff");
        mountAnimator.SetTrigger("Kill");
    }

    //Mount
    public void mount()
    {
        aManager.Play("Mount");
        mountObject.SetActive(true);
        bombermanAnimator.ResetTrigger("EndJump");
        bombermanAnimator.SetTrigger("JumpOn");
        bombermanAnimator.SetBool("Riding", true);
        mountAnimator.SetInteger("Direction", bombermanAnimator.GetInteger("Direction"));
    }

    //Flash Sprite
    public void flashSprite()
    {
        if (flashSpriteInterval <= 0f)
        {
            bombermanSpriteRenderer.enabled = !bombermanSpriteRenderer.enabled;
            flashSpriteInterval = 0.1f;
        }
        else flashSpriteInterval -= Time.deltaTime;
    }

    //Set Victory Animation
    public void setVictoryAnimation(bool riding)
    {
        bombermanAnimator.SetTrigger("Victory");
        if(riding) mountAnimator.SetTrigger("Victory");
    }

    //get State Animation
    public bool isEndOfTeleportAnimation()
    {
        if (bombermanAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Teleport"))
        {
            return bombermanAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f;
        }
        else return false;
    }
}
