using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class cameraMovement : MonoBehaviour {

	public Transform target;
	public float m_speed = 0.1f;
	public float zoom;
	public bool isCutscene;
	Camera mycam;

	Vector3 position;

	// Use this for initialization
	void Start () {
		mycam = GetComponent<Camera> ();

/*		if (StairManager.Stair == null)
		{
			position = GameController.lastPosition[SceneManager.GetActiveScene().buildIndex];

		}
		else if (StairManager.Stair.Equals("Left"))
		{
			position = GameObject.FindGameObjectWithTag("LeftSpawn").transform.position;
		}
		else if (StairManager.Stair.Equals("Right"))
		{
			position = GameObject.FindGameObjectWithTag("RightSpawn").transform.position;
		}
*/
		Debug.Log(position);
		if (position != Vector3.zero)
		{
			gameObject.transform.position = position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		mycam.orthographicSize = (Screen.height / 100f / zoom);
		if (isCutscene) 
		{
			return;
		}

		if (target) {
			transform.position = Vector3.Lerp (transform.position, target.position, m_speed) + new Vector3(0,0,-10);

		}
	}
}
