using UnityEngine;
using System.Collections;

public class SnakeWave : MonoBehaviour {
	public GameObject[] goSnakeBox;
	float theta;
	const float pi2=2*Mathf.PI;
	const float steps=60;
	const float delta=pi2/steps;
	int isegs=1;
	float phasediff = pi2 / 6;

	int dx=1;
	float deltax=0.4f;
	public bool xMove=false;
	float origx=0,origz=0;
	// Use this for initialization
	void Start () {
		isegs = goSnakeBox.Length;
		origx = gameObject.transform.position.x;
		origz = gameObject.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {

		if (xMove) 
		{
			if (gameObject.transform.position.x - origx < 0 || gameObject.transform.position.x - origx > 10) {
				dx = -dx;
			}
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x + deltax * dx, gameObject.transform.position.y, gameObject.transform.position.z);
		}
		for (int i = 0; i < isegs; ++i)
			goSnakeBox [i].transform.position = new Vector3(goSnakeBox [i].transform.position.x,goSnakeBox [i].transform.position.y, origz+Mathf.Sin (theta + phasediff*i));
		theta = theta + delta;
	}
}
