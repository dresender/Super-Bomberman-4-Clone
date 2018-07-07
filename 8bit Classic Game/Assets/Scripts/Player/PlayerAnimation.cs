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
	
	//Set Animation
    public void setAnimation(bool moving, int direction)
    {
        animator.SetInteger("Direction", direction);
        animator.SetBool("Moving", moving);
    }

    //Set Animation
    public void setAnimation(bool moving)
    {
        animator.SetBool("Moving", moving);
    }
}
