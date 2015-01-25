using UnityEngine;
using System.Collections;

public class PlayerSurvival : MonoBehaviour {

	public float speed = 6f;

	public CharacterController control;
	public ChivoHumanController chivo;
	Vector3 movement;
	bool 	dead;
//	Animator anim;
	Rigidbody playerRigidbody;
//	int floorMask;

	
	void Awake()
	{
//		floorMask = LayerMask.GetMask ("Floor");
//		anim = GetComponent<Animator> ();
		control= this.GetComponent("CharacterController") as CharacterController;
		playerRigidbody = GetComponent<Rigidbody> ();
	}
	
	void FixedUpdate()
	{
		float h = Input.GetAxisRaw ("Horizontal_01");
		float v = Input.GetAxisRaw ("Vertical_01");
		
		Move (h, v);
//		Turning ();
//		Animating (h, v);
	}
	
	void Move(float h, float v)
	{
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		if (this.dead) movement= Vector3.zero;

		if (this.chivo) {
			this.chivo.walk((movement!= Vector3.zero));
			this.chivo.setDirection(movement);
		}


		control.Move(movement);
	}

	public void kill() {
		if (this.dead) return;
		this.dead= true;
		Debug.Log("Deaaaaaad");
		Invoke("RestartScene",2);
	}

	void RestartScene() {
		if (this.chivo) this.chivo.die();
		Application.LoadLevel(Application.loadedLevel);
	}

}
