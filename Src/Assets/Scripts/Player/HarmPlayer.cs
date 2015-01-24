using UnityEngine;
using System.Collections;

public class HarmPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		// Add the player to our current present player count
		if (other.collider.tag== "Player") {
			if (other.collider.gameObject.GetComponent("PlayerManager"))
				(other.collider.gameObject.GetComponent("PlayerManager") as PlayerManager).kill();

			if (other.collider.gameObject.GetComponent("PlayerSurvival"))
				(other.collider.gameObject.GetComponent("PlayerSurvival") as PlayerManager).kill();

			Destroy(other.collider.gameObject);
		}
	}
}
