using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public float timer = 3f;
	public float timeDecrease = 0.1f;
	public GameObject menuBumble;


	private bool changing = false;

	public AudioClip klunk;
	private AudioSource source;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			change();
			source.PlayOneShot(klunk, 1);
			//Application.LoadLevel ("testscene");
			//Debug.Log("knapp");
		}

		if (changing) {
			timer -= timeDecrease;
			if(timer < 0)
			{
				Application.LoadLevel ("testscene");
			}
			GetComponent<Rigidbody2D>().AddForce(new Vector2(15, 0f));
			menuBumble.GetComponent<Animator>().SetTrigger("flap");
		}
	}

	void change(){
		changing = true;
		GetComponent<Rigidbody2D> ().isKinematic = false;
	}
}
