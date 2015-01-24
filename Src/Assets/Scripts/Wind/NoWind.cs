using UnityEngine;
using System.Collections;

public class NoWind : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		print("Trigger was Hit");
	}
}
