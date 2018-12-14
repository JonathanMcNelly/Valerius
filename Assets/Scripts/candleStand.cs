using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candleStand : Overlap_Generic {

	public AudioClip StrikeMatch;
	private Animator anim;
	public bool isLit;

	// Use this for initialization
	void Start () {

		anim = gameObject.GetComponent<Animator> ();

		if (!isLit) {
		
			gameObject.GetComponentInChildren<Light> ().enabled = false;
			anim.SetBool ("isLit", false);
		}
		if (isLit) {
			gameObject.GetComponentInChildren<Light> ().enabled = true;
			anim.SetBool ("isLit", true);
		
		}

	}
	
	// Update is called once per frame
	void Update () {

        //if (overlap && Inventory.currentItem.Equals (Inventory.Items.Matches) && !isLit) {

        if (overlap) { 
			AudioSource.PlayClipAtPoint (StrikeMatch, Camera.main.transform.position, 0.3f);
			gameObject.GetComponentInChildren<Light> ().enabled = true;
			anim.SetBool ("isLit", true);
			isLit = true;
		
		}


	}
}
