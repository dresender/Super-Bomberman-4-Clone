using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraEgg : MonoBehaviour
{
    //Variables
    private bool active;
    private Animator animator;
    private LinkedList<Vector2> lastPositions;
    private bool expended;
    private Vector2 target;

    // Use this for initialization
    void Start ()
    {
        expended = false;
        active = true;
        animator = this.GetComponent<Animator>();
        lastPositions = new LinkedList<Vector2>();
    }

    //Save Position
    private Vector2 savePosition(Vector2 position)
    {
        if (lastPositions.Count == 0)
        {
            lastPositions.AddFirst(position);
            return position;
        }
        else if (lastPositions.Last.Value != position)
        {
            Vector2 result = lastPositions.First.Value;
            if (lastPositions.Count == ControllerManager.Instance.extraEggsController.delayExtraEggMovement) lastPositions.RemoveFirst();
            lastPositions.AddLast(position);
            return result;
        }
        else return lastPositions.First.Value;
    }

    //Destroy Egg
    public void destroyEgg(bool terminate = false)
    {
        if(active)
        {
            active = false;
            animator.SetTrigger("Destroy");
            ControllerManager.Instance.extraEggsController.destroyExtraEgg(this.gameObject);
            if (terminate) Destroy(this.gameObject);
        }
    }

    //Movement Logic
    public Vector2 move(Vector2 desiredPosition)
    {
        Vector2 result = savePosition(this.transform.position);
        this.transform.position = desiredPosition;
        return result;
    }

    //Expend Egg Logic
    public void expendEgg(Vector2 target)
    {
        if (!expended)
        {
            expended = true;
            this.target = target;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (!active)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Destroy") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f) Destroy(this.gameObject);
        }

        if(expended)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, target, 3f * Time.deltaTime);
        }
    }
}
