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
        animator = this.GetComponent<Animator>();
    }

    //Set Animation
    public void setAnimation(int direction)
    {
        animator.SetInteger("Direction", direction);
    }
}
