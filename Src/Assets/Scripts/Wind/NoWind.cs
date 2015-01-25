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
		if (neverRemove) return;

		if (!interruptorOn && this.targets.Count==0) 	this.transform.parent.gameObject.SetActive(false);

	}
	
	void OnTriggerEnter(Collider other)
	{
		// Add the player to our current present player count
		if (other.collider.tag== "Player") {
			if (!this.targets.Contains (other.gameObject)) 
				this.targets.Add(other.gameObject);
			// Set on interruptor of target sensor
			if (this.anotherWall) {
				this.anotherWall.SetActive(true);
				if (this.anotherWall.transform.childCount>0)
					if (this.anotherWall.transform.GetChild(0).GetComponent("NoWind")) 
						(this.anotherWall.transform.GetChild(0).GetComponent("NoWind") as NoWind).interruptorOn= true;
			}
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.collider.tag== "Player") {
			if (this.targets.Contains (other.gameObject)) { 
				// Remove the player from our current present player count
				this.targets.Remove (other.gameObject);
				if (targets.Count==0) {
					// Set off interruptor of target sensor
					if (this.anotherWall) {
						if (this.anotherWall.transform.childCount>0){
							if (this.anotherWall.transform.GetChild(0).GetComponent("NoWind")) 
							(this.anotherWall.transform.GetChild(0).GetComponent("NoWind") as NoWind).interruptorOn= false;
						}
					}
				}
			}
		}
	}
}
