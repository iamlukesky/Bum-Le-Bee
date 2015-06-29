using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

	public Sprite[] sprites;

	private float angle = 0f;
	private float angleInc = 0.05f;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer>().sprite = sprites[(int)Random.Range(0, sprites.Length)];
		float theScale = Random.Range (0.8f, 1.3f);
		transform.localScale = new Vector3 (theScale, theScale, 0f);
	}
	
	// Update is called once per frame
	void Update () {
//		float rotate = Mathf.Sin (angle) * 0.5f;
//		//transform.rotation.Set(0f, 0f, rotate, 0f);
//		Debug.Log (transform.localRotation + " " + rotate);
//
//		transform.Rotate (Vector3.forward, rotate);
//		//transform.localRotation = new Quaternion(transform.rotation.x, transform.rotation.y, rotate, 0f);
//			//= new Quaternion(transform.rotation.x, transform.rotation.y, Mathf.Sin (angle) * 30, 0f);
//		angle += angleInc;
//			//(transform.rotation.x, transform.rotation.y, Mathf.Sin (angle) * 30);
	}

}
