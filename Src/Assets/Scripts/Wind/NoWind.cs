using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NoWind : MonoBehaviour {

	public GameObject anotherWall;
	public List<Transform>targets;

	// Use this for initialization
	void Start () {
		targets= new List<GameObject>;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay(Collider other)
	{
		if (other.collider.tag== "Player") {
			print("Turn wall on");
			if (this.anotherWall) this.anotherWall.SetActive(true);
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.collider.tag== "Player") {
			print("Turn wall off");
			if (this.anotherWall) this.anotherWall.SetActive(false);
		}
	}
}
