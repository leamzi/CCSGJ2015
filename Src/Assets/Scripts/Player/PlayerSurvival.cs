using UnityEngine;
using System.Collections;

public class PlayerSurvival : MonoBehaviour {

	public float speed = 6f;

	public CharacterController control;
	public ChivoHumanController chivo;
	Vector3 movement;
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
		Turning ();
//		Animating (h, v);
	}
	
	void Move(float h, float v)
	{
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;

		if (this.chivo) {
			this.chivo.walk((movement!= Vector3.zero));
			this.chivo.setDirection(movement);
		}

		control.Move(movement);
	}

	public void kill() {
		Debug.Log("Dead");
	}
	
	void Turning()
	{
//		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
//		
//		RaycastHit floorHit;
//		
//		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) 
//		{
//			Vector3 playerToMouse = floorHit.point - transform.position;
//			playerToMouse.y = 0f;
//			
//			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
//			playerRigidbody.MoveRotation(newRotation);
//		}
	}
	
//	void Animating (float h, float v)
//	{
//		// Create a boolean that is true if either of the input axes is non-zero.
//		bool walking = h != 0f || v != 0f;
//		
//		// Tell the animator whether or not the player is walking.
//		anim.SetBool ("IsWalking", walking);
//	}
}
