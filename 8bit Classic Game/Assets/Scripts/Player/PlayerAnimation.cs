using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //Variables
    private Animator animator;

    // Use this for initialization
    void Start ()
    {
        animator = this.transform.GetChild(0).GetComponent<Animator>();
    }

    //Set Movement Animation
    public void setMovementAnimation(bool moving, int direction)
    {
        animator.SetInteger("Direction", direction);
        animator.SetBool("Moving", moving);
    }

    //Set Movement Animation
    public void setMovementAnimation(bool moving)
    {
        animator.SetBool("Moving", moving);
    }

    //get State Animation
    public float getStateAnimation()
    {
        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    //Set Death Animation
    public void setDeathAnimation()
    {
        animator.SetTrigger("Kill");
    }
}
