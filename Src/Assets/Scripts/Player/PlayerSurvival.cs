using UnityEngine;
using System.Collections;

public class PlayerSurvival : MonoBehaviour {

	/*MOVEMENT*/
//	public CharacterController control;
//
//	private Vector3 localMoveDirection;
//	private Vector3 moveDirection;
//	private float 	speed= 10;
//	
//	void Awake()
//	{
//		control= this.GetComponent("CharacterController") as CharacterController;
//	}
//	
//	void Update()
//	{
//		movement();
//	}
//	
//	/*CHECKS FOR MOVEMET*/
//	private void movement()
//	{
//		// este es el que vamos a usar:
//		localMoveDirection= new Vector3(Input.GetAxis("Horizontal_01"), 0, Input.GetAxis("Vertical_01"));
//		
//		moveDirection= this.transform.TransformDirection(localMoveDirection);
//		
//		control.Move(speed * moveDirection * Time.deltaTime);
//	}

	public float speed = 6f;
	
	Vector3 movement;
//	Animator anim;
	Rigidbody playerRigidbody;
//	int floorMask;
	
	void Awake()
	{
//		floorMask = LayerMask.GetMask ("Floor");
//		anim = GetComponent<Animator> ();
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
		
		playerRigidbody.MovePosition (transform.position + movement);
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
