using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    //Variables
    private Animator animator;

	// Use this for initialization
	void Start ()
    {
        animator = this.transform.GetChild(0).GetComponent<Animator>();
        setAnimation(0);
    }

    //Set Animation
    public void setAnimation(int direction)
    {
        animator.SetInteger("Direction", direction);
    }

    //Pause Animation
    public void pauseAnimation()
    {
        animator.enabled = false;
    }

    //Resume Animation
    public void resumeAnimation()
    {
        animator.enabled = true;
    }
}
