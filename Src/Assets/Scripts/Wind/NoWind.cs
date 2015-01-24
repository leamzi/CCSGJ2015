using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NoWind : MonoBehaviour {

	public GameObject anotherWall;
	public bool interruptorOn;
	public bool neverRemove;

	public List<GameObject> targets;

	void Awake(){
		targets= 	new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		if (targets.Count==0 && !interruptorOn && !neverRemove) 	this.transform.parent.gameObject.SetActive(false);
		else 													this.transform.parent.gameObject.SetActive(true);
	}
	
	void OnTriggerStay(Collider other)
	{
		if (other.collider.tag== "Player") {
			print("Turn wall on");
			if (!this.targets.Contains (other.gameObject)) 
				this.targets.Add(other.gameObject);
			if (this.anotherWall) (this.anotherWall.transform.GetChild(0).GetComponent("NoWind") as NoWind).interruptorOn= true;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.collider.tag== "Player") {
			if (this.targets.Contains (other.gameObject)) { 
				this.targets.Remove (other.gameObject);
				if (targets.Count==0) {
					(this.anotherWall.GetComponent("NoWind") as NoWind).interruptorOn= false;
				}
			}
		}
	}
}
