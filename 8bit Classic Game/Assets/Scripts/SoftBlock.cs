using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SoftBlock : MonoBehaviour
{
    private Animator animator;
    public GameObject powerup;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
		if(animator.enabled && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            if(powerup != null) Instantiate(powerup, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
	}
}
