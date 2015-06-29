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
		int energyIndex;
		energyIndex = (int)player.energy - 1;
		//Debug.Log (energyIndex);
		/*
		if (energyIndex >= energylevels.Length) {
			energyIndex = energylevels.Length;
		}
		*/
		if (energyIndex <= 0) {
			energyIndex = 0;
		}


		GetComponent<SpriteRenderer>().sprite = energylevels[energyIndex]; 
	}
}