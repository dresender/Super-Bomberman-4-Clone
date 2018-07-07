using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Explosion : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        //If Animation Ended -> Destroy Self
        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) Destroy(this.gameObject);
    }

    //Explosion Collision
    void OnTriggerEnter2D()
    {
        //TODO!
    }

    
}
