using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    //Variables
    private bool activated;

    //Start Method
    private void Start()
    {
        activated = false;
    }

    //When Player Steps on Portal
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!activated)
        {
            if (collision.CompareTag("Player"))
            {
                if ((this.transform.position - collision.transform.position).magnitude <= 0.2f)
                {
                    activated = true;
                    collision.GetComponent<PlayerState>().setVictory();
                    collision.transform.position = this.transform.position;
                }
            }
        }
    }
}
