using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Explosion : MonoBehaviour
{
    public void setAnimation(int animType)
    {
        GetComponent<Animator>().SetInteger("ExplosionSide", animType);
        GetComponent<Animator>().SetTrigger("Begin");
    }
}
