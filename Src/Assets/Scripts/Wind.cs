using UnityEngine;
using System.Collections;

public class Wind : MonoBehaviour {

	public Vector3 windDirection;
	public bool wind= true;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag== "Player") {
			Debug.Log("WIND");
			(other.gameObject.GetComponent("CharacterController") as CharacterController).Move(windDirection);
		}
	}
}
