using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    //Variables
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private float flashSpriteInterval;

	// Use this for initialization
	void Start ()
    {
        spriteRenderer = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        animator = this.transform.GetChild(0).GetComponent<Animator>();
        flashSpriteInterval = 0f;
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

    //Flash Sprite
    public void flashSprite()
    {
        if (flashSpriteInterval <= 0f)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            flashSpriteInterval = 0.1f;
        }
        else flashSpriteInterval -= Time.deltaTime;
    }

    //Resume Animation
    public void resumeAnimation()
    {
        animator.enabled = true;
        flashSpriteInterval = 0f;
    }
}
