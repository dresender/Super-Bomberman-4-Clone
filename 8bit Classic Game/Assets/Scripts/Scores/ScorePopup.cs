using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePopup : MonoBehaviour
{
    //Internal Variables
    private Animator animator;
    private GameObject firstNumber;
    private Vector2 target;
    private bool rising;
    private float duration;

	// Use this for initialization
	void Start ()
    {
        animator = this.GetComponent<Animator>();
        firstNumber = this.transform.GetChild(0).gameObject;
        target = (Vector2) this.transform.position + (Vector2.up * 0.5f);
        rising = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(rising)
        {
            if (((Vector2)this.transform.position - target).magnitude == 0f) Destroy(this.gameObject);
            else this.transform.position = Vector2.MoveTowards(this.transform.position, target, 0.15f * Time.deltaTime);
        }
		else if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            firstNumber.SetActive(true);
            rising = true;
        }
	}
}
