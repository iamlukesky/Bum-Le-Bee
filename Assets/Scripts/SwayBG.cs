using UnityEngine;
using System.Collections;

public class SwayBG : MonoBehaviour {

	float angle = 0.0f;
	float angleInc = 0.01f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		angle += angleInc;
		float move = Mathf.Sin (angle*1.5f);
		float move2 = Mathf.Cos (angle) * move;
		move2 *= -1;

		transform.position = new Vector3 (move2, move, 0f);
		transform.Rotate (new Vector3(0f, 0f, move2));// n = new Quaternion (0f, 0f, move, 0f);
	}
}
