using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Explosion : MonoBehaviour
{
    //Variables
    private Animator animator;
    private BoxCollider2D collider;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        collider = this.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        //If Animation Ended -> Destroy Self
        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) Destroy(this.gameObject);
        else
        {
            Collider2D[] collisions = new Collider2D[1]; //-> Ignore Itself
            int contacts = collider.GetContacts(collisions);

            if (contacts > 0)
            {
               if(collisions[0].CompareTag("Enemy")) collisions[0].GetComponent<EnemyAI>().killEnemy();
               else if(collisions[0].CompareTag("Player")) collisions[0].GetComponent<PlayerState>().killPlayer();
            }
        }
    }
}
