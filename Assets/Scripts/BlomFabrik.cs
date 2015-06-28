using UnityEngine;
using System.Collections;

public class BlomFabrik : MonoBehaviour {

	public int antalBlommor;
	//public Transform blomma;

	public int spawnAreaTop;
	public int spawnAreaBottom;
	public int spawnAreaLeft;
	public int spawnAreaRight;

	// Use this for initialization
	void Start () {
		GameObject prefab = Resources.Load ("blomma") as GameObject;

		for (int i = 0; i < antalBlommor; i++) {

		//	Vector3 pos = new Vector3( Random.Range(spawnAreaLeft, spawnAreaRight), Random.Range(spawnAreaTop, spawnAreaBottom), 0f);

			//Instantiate(blomma, pos, Quaternion.identity);
			//GameObject blomma = new GameObject<Blomma>();
			//blomma.transform.position = new Vector3(Random.Range(0, 100), Random.Range(0, 50), 0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
