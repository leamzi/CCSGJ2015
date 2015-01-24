using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeScene : MonoBehaviour {

	public GameObject anotherWall;
	public int NextLevelNumber;
	public bool interruptorOn;
	public bool neverRemove;
	public bool isOnSurvival;
	
	public List<GameObject> targets;
	
	void Awake(){
		targets= 	new List<GameObject>();
	}
	
	// Update is called once per frame
//	void Update () {
//		if (neverRemove) return;
//		
//		if (!interruptorOn && this.targets.Count==0) 	this.transform.parent.gameObject.SetActive(false);
//		
//	}
	
	void OnTriggerEnter(Collider other)
	{
		// Add the player to our current present player count
		if (other.collider.tag== "Player") {
			if (!this.targets.Contains (other.gameObject)) 
				this.targets.Add(other.gameObject);
		}

		//Check to see if both players
		if(this.targets.Count == 2)
		{
			Application.LoadLevel(NextLevelNumber);
		} else if (this.targets.Count == 1 && isOnSurvival)
		{
			Application.LoadLevel(NextLevelNumber);
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.collider.tag== "Player") {
			if (this.targets.Contains (other.gameObject)) { 
				// Remove the player from our current present player count
				this.targets.Remove (other.gameObject);
			}
		}
	}
}
