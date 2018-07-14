using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraEgg : MonoBehaviour
{
    //Variables
    private bool active;
    private Animator animator;
    private Vector2 lastPosition;
    //private LinkedList<Vector2> lastPositions;
    //public int delayExtraEggMovement;

    // Use this for initialization
    void Start ()
    {
        active = true;
        animator = this.GetComponent<Animator>();
        //lastPositions = new LinkedList<Vector2>();
        lastPosition = this.transform.position;
    }

    //Save Position
    /*
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
            if (lastPositions.Count == delayExtraEggMovement) lastPositions.RemoveFirst();
            lastPositions.AddLast(position);
            return result;
        }
        else return lastPositions.First.Value;
    }
    */

    //Destroy Egg
    public void destroyEgg()
    {
        if(active)
        {
            active = false;
            animator.SetTrigger("Destroy");
            ControllerManager.Instance.extraEggsController.destroyExtraEgg(this.gameObject);
        }
    }

    //Movement Logic
    public Vector2 move(Vector2 desiredPosition)
    {
        lastPosition = this.transform.position;
        this.transform.position = desiredPosition;
        return lastPosition;
    }

    // Update is called once per frame
    void Update ()
    {
        if (!active)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Destroy") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f) Destroy(this.gameObject);
        }
    }
}
