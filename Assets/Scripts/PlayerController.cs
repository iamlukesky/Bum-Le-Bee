using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//public AudioClip buzzSound;
	//public AudioClip flapSound;
	//private AudioSource source;

	private bool facingRight = false;

	private Rigidbody2D rb;
	public float power;
	public int rightEdge;
	public int leftEdge;
	public int topEdge;
	public int bottomEdge;
	private Animator animator;

	public float energy;
	public float energyDecrease;
	public float energyMax;
	public float energyMin;

	public float powerDecrease;

	public int nectar;

	public float maxVelocity;

	private bool flapping = false;



	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D> ();
		//source = GetComponent<AudioSource> ();

		//source.clip = buzzSound;
		//source.loop = true;
		//source.Play ();

	}
	
	// Update is called once per frame
	void Update () {



	}

	void checkEdges(){
		if (transform.position.x >= rightEdge) {
			Vector3 vel = rb.velocity;
			vel.x = 0;
			rb.velocity = vel;
			Vector3 pos = transform.position;
			pos.x = rightEdge;
			transform.position = pos;
		} if (transform.position.x <= leftEdge) {
			Vector3 vel = rb.velocity;
			vel.x = 0;
			rb.velocity = vel;
			Vector3 pos = transform.position;
			pos.x = leftEdge;
			transform.position = pos;
		} if (transform.position.y <= topEdge) {
			Vector3 vel = rb.velocity;
			vel.y = 0;
			rb.velocity = vel;
			Vector3 pos = transform.position;
			pos.y = topEdge;
			transform.position = pos;
		} if (transform.position.y >= bottomEdge) {
			Vector3 vel = rb.velocity;
			vel.y = 0;
			rb.velocity = vel;
			Vector3 pos = transform.position;
			pos.y = bottomEdge;
			transform.position = pos;

			//gameOver();
		}
	}

	void OnTriggerEnter2D(Collider2D other){ //Collider2D
		if (other.gameObject.CompareTag("Pick Up") && rb.velocity.magnitude < 2) {
			other.gameObject.SetActive(false);
			//Destroy(other.gameObject);
			//Debug.Log("Träff");
		}
	}

	private void flip()
	{
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		//Debug.Log (theScale);
		theScale.x *= -1;
		transform.localScale = theScale;
		//transform.localScale *= new Vector3 (-1, 0, 0);
		//transform.localScale = new Vector3(transform.localScale.x * -1, 0, 0);
	}

	void FixedUpdate(){
		//movement
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		if (energy <= 0 && moveVertical > 0) {
			moveVertical = 0;
		}
		
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb.AddForce(movement * power);
		rb.velocity = Vector3.ClampMagnitude (rb.velocity, maxVelocity);

		//sprite orientation
		if (Input.GetKeyDown (KeyCode.RightArrow) && facingRight == false) {
			flip ();
		} else if (Input.GetKeyDown (KeyCode.LeftArrow) && facingRight == true) {
			flip ();	
		}
		
		//trigger flapping animation
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			flapping = true;
		}
		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			flapping = false;
		}
		if (flapping) {
			animator.SetTrigger("flap");
		}
		
		//energylevels
		if (flapping) {
			energy -= energyDecrease;
		}else{
			energy += energyDecrease;
		}
		if (energy <= energyMin) {
			energy = energyMax;
			power -= powerDecrease;
			
		}
		if (energy >= energyMax) {
			energy = energyMax;
		}
		
		checkEdges ();
		//Debug.Log (energy);
	}
}
