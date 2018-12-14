using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlap_Generic : MonoBehaviour {



	public Transform pointA, pointB;
	public TextAsset theText;

	public int startLine, endLine;
	public AudioClip InteractionSound;
	public float Volume;

    //[HideInInspector]

    //public TextboxManager textBox;
	//[HideInInspector]
	//public ActivateTextAtLine textAtLine;
	public LayerMask layer;
	[HideInInspector]
	public bool overlap;

	public float cooldown = 1.0f;

	void FixedUpdate()
	{
		overlap = Physics2D.OverlapArea(pointA.position, pointB.position, layer);
	}
}