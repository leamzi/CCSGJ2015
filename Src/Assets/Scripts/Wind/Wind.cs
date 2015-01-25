using UnityEngine;
using System.Collections;

public class Wind : MonoBehaviour {
	
	public Vector3 windDirection;
	public bool wind= true;
	public float windDuration= 3;
	public GameObject windVFX;
	public AudioSource source;

	// Use this for initialization
	void Start () {
		ThrowWind();
		InvokeRepeating("WindOn" ,1 				, 2*windDuration);
		InvokeRepeating("WindOff",1 +windDuration	, 2*windDuration);
	}

	void Update() {
		if (this.wind) 	{this.ThrowWind(); 	this.windVFX.SetActive(true);}
		else 			{					this.windVFX.SetActive(false);}
	}

	void WindOn() {
		this.source.Play();
		this.wind= true;
	}

	void WindOff() {
		this.source.Stop();
		this.wind= false;
	}

	void ThrowWind() {
		Messenger<Vector3>.Broadcast("Wind", windDirection);
	}

	void OnEnable()
	{
		Messenger<Vector3>.AddListener("Wind", ApplyWind);
	}
	
	void OnDisable()
	{
		Messenger<Vector3>.RemoveListener("Wind", ApplyWind);
	}
	
	void ApplyWind(Vector3 windDirection)
	{
		;
	}
}
