using UnityEngine;
using System.Collections;

public class PlayerSurvival : MonoBehaviour {

	/*MOVEMENT*/
	public CharacterController control;

	private Vector3 localMoveDirection;
	private Vector3 moveDirection;
	private float 	speed= 10;
	
	void Awake()
	{
		control= this.GetComponent("CharacterController") as CharacterController;
	}
	
	void Update()
	{
		movement();
	}
	
	/*CHECKS FOR MOVEMET*/
	private void movement()
	{
		// este es el que vamos a usar:
		localMoveDirection= new Vector3(Input.GetAxis("Horizontal_01"), 0, Input.GetAxis("Vertical_01"));
		
		moveDirection= this.transform.TransformDirection(localMoveDirection);
		
		control.Move(speed * moveDirection * Time.deltaTime);
	}
}
