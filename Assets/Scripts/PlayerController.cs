using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int deathLevel;

	public bool alive = true;

	public float energyDecay = 0.001f;

	private float lastTime;

	public AudioClip morr;
	public AudioClip drickljud;
	public AudioClip blomljud;
	public AudioClip buzzSound;
	private AudioSource source;

	private bool facingRight = false;

	private Rigidbody2D rb;
	public float power;
	public int rightEdge;
	public int leftEdge;
	public int topEdge;
	public int bottomEdge;
	public int energyForFlower;
	public int energyForBooze;
	private Animator animator;

	public float pickupVelocity;

	public float energy;
	public float energyDecrease;
	public float energyMax;
	public float energyMin;

	public float powerDecrease;

	public int nectar;

	public float maxVelocity;

	private bool flapping = false;

	//public BlomFabrik blomfabrik;



	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D> ();
		source = GetComponent<AudioSource> ();

		source.clip = buzzSound;
		source.loop = true;
		source.Play ();

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
		if (other.gameObject.CompareTag("Pick Up") && rb.velocity.magnitude < pickupVelocity) {
			other.gameObject.SetActive(false);
			source.PlayOneShot(blomljud, 1);
			//Destroy(other.gameObject);
			//blomfabrik.blommor.Remove(other.gameObject);
			Debug.Log("Removed flower");
			//int nrOfFLowers = blomfabrik.Count;
			//Debug.Log ("Number of flowers = " + nrOfFlowers);
			if (energy+energyForFlower<=energyMax) {
				energy += energyForFlower;
			}


		}
		if (other.gameObject.CompareTag("Power Up")) {//&& rb.velocity.magnitude < pickupVelocity) {
			other.gameObject.SetActive(false);
			//Destroy(other.gameObject);
			//blomfabrik.blommor.Remove(other.gameObject);
			Debug.Log("Removed booze");
			//int nrOfFLowers = blomfabrik.Count;
			//Debug.Log ("Number of flowers = " + nrOfFlowers);
			energy = energyMax;
			if(power-20 > 1){
			maxVelocity += 5; //0.5;
			power -= 20;
			}
			source.PlayOneShot(drickljud, 1);
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
		
		if (energy <= energyMin && moveVertical > 0) {
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
			energy -= energyDecay;
		}
		if (energy <= energyMin) {
			//energy = energyMax;
			//power -= powerDecrease;
			energy = energyMin;
		}
		if (energy >= energyMax) {
			energy = energyMax;
		}

		if (transform.position.y < deathLevel && alive) {
			//if(alive){
				animator.SetTrigger("deathAnim");
				//transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y - 0.5f, 0f);
				alive = false;
				rb.isKinematic = true;
			lastTime = Time.time;
			source.PlayOneShot(morr, 1);
			//}
		}

		if (!alive && Time.time - lastTime > 1.3f) {
			Application.LoadLevel ("mainMenu");
		}


		
		checkEdges ();
		//Debug.Log (energy);
	}
}
