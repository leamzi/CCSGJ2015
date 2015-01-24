using UnityEngine;
using System.Collections;


public class PlayerManager : MonoBehaviour
{

	/*MOVEMENT*/
	public CharacterController control;
	public string playerNumber = "_01";
	private Vector3 localMoveDirection;
	private Vector3 moveDirection;
	private float 	speed= 10;
	private bool 	windInmune;

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
		localMoveDirection= new Vector3(Input.GetAxis("Horizontal" + playerNumber), 0, Input.GetAxis("Vertical"+ playerNumber));

		moveDirection= this.transform.TransformDirection(localMoveDirection);
		
		control.Move(speed * moveDirection * Time.deltaTime);
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
		if (windInmune) return;
		control.Move(windDirection);
	}

	void OnTriggerStay(Collider other)
	{
		print("Player was Hit");
		if (other.collider.tag== "NoWind") this.windInmune=  true;
	}

	void OnTriggerExit(Collider other)
	{
		print("Player was Hit");
		if (other.collider.tag== "NoWind") this.windInmune=  false;
	}

}
