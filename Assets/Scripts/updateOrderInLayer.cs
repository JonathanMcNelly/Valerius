using UnityEngine;
using System.Collections;

public class updateOrderInLayer : MonoBehaviour {

	private SpriteRenderer spriteRenderer;




	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();

	}


	void Update()
	{

	
		spriteRenderer.sortingOrder= (int)Camera.main.WorldToScreenPoint (spriteRenderer.bounds.min).y * -1;
	}
}
