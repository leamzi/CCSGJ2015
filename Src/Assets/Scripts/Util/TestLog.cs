using UnityEngine;
using System.Collections;

public class TestLog : MonoBehaviour {

	public UILabel text;

	// Use this for initialization
	void Start () {
		;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnEnable()
	{
		Messenger<Vector3>.AddListener("GOAT DIED", goatDied);
		Messenger<Vector3>.AddListener("HUMAN DIED", humanDied);
	}
	
	void OnDisable()
	{
		Messenger<Vector3>.RemoveListener("GOAT DIED", goatDied);
		Messenger<Vector3>.AddListener("HUMAN DIED", humanDied);
	}

	void goatDied(Vector3 target) {
		if (this.text) this.text.text= "GOAT DIED";
	}

	void humanDied(Vector3 target) {
		if (this.text) this.text.text= "HUMAN DIED";
	}

}
