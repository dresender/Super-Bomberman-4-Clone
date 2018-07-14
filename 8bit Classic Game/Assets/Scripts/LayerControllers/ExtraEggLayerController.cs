using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraEggLayerController : MonoBehaviour
{
    private SpriteRenderer sprtRenderer;
    private SpriteRenderer bombermanSpriteRenderer;
    private bool downMovement;

	void Start ()
    {
        downMovement = false;
        sprtRenderer = this.GetComponent<SpriteRenderer>();
        bombermanSpriteRenderer = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    public void setDownMovement(bool downMovement)
    {
        this.downMovement = downMovement;
    }

	void LateUpdate ()
    {
        if(!downMovement) sprtRenderer.sortingOrder = bombermanSpriteRenderer.sortingOrder - 1;
        else sprtRenderer.sortingOrder = bombermanSpriteRenderer.sortingOrder + 1;
    }
}
