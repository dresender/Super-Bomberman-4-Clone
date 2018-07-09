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
        else
        {
            Collider2D collision = Physics2D.OverlapBox(this.transform.position, new Vector2(0.75f, 0.75f), 0f);
            if((collision != null) && (collision.CompareTag("Enemy"))) collision.GetComponent<EnemyAI>().killEnemy();
        }
    }
}
