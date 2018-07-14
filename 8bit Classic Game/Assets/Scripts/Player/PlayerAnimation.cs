using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //Variables
    private Animator bombermanAnimator;
    private Animator mountAnimator;
    private MountLayerController mountLayerController;
    private GameObject mountObject;

    // Use this for initialization
    void Start ()
    {
        bombermanAnimator = this.transform.GetChild(0).GetComponent<Animator>();
        mountAnimator = this.transform.GetChild(1).GetComponent<Animator>();
        mountLayerController = this.transform.GetChild(1).GetComponent<MountLayerController>();
        mountObject = this.transform.GetChild(1).gameObject;
        mountObject.SetActive(false);
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
        bombermanAnimator.SetBool("Riding", false);
        bombermanAnimator.SetTrigger("JumpOff");
        mountAnimator.SetTrigger("Kill");
    }

    //Mount
    public void mount()
    {
        mountObject.SetActive(true);
        bombermanAnimator.SetTrigger("JumpOn");
        bombermanAnimator.SetBool("Riding", true);
        mountAnimator.SetInteger("Direction", bombermanAnimator.GetInteger("Direction"));
    }

    //Set Victory Animation
    public void setVictoryAnimation(bool riding = false)
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
