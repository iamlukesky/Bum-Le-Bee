using UnityEngine;
using System.Collections;

public class EnergyBar : MonoBehaviour {

	public Sprite[] energylevels;
	public PlayerController player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<SpriteRenderer>().sprite = energylevels[(int)player.energy]; 
	}
}
