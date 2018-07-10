using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerController : MonoBehaviour
{
    private SpriteRenderer sprtRenderer;

	void Start ()
    {
        sprtRenderer = this.GetComponent<SpriteRenderer>();
	}	

	void LateUpdate ()
    {
        sprtRenderer.sortingOrder = -(int)transform.position.y;
	}
}
