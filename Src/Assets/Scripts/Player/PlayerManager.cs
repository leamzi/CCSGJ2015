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
	public  bool 	windInmune;
	public  bool 	dead;

	public ChivoController chivo;
	public HumanController human;

	private Vector3 lastPosition;

	void Awake()
	{
		control= this.GetComponent("CharacterController") as CharacterController;
	}

	void Update()
	{
		movement();
	}

	bool moving ()
	{
		if (lastPosition != gameObject.transform.position)
		{
			lastPosition = gameObject.transform.position;
			return true;
		}
		lastPosition = gameObject.transform.position;
		return false;

	}
	
	/*CHECKS FOR MOVEMET*/
	private void movement()
	{

		// este es el que vamos a usar:
		localMoveDirection= new Vector3(Input.GetAxis("Horizontal" + playerNumber), 0, Input.GetAxis("Vertical"+ playerNumber));

		if (this.dead) localMoveDirection= Vector3.zero;

		if (this.chivo) {
			this.chivo.walk((this.localMoveDirection!= Vector3.zero));
			this.chivo.setDirection(localMoveDirection);
		}
		if (this.human) {
			this.human.walk((this.localMoveDirection== Vector3.zero));
			this.human.setDirection(localMoveDirection);
		}


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

	public void kill() {
		print("Dead");
		if (this.dead) return;
		this.dead= true;
		Invoke("RestartScene",2);
		if (this.chivo) this.chivo.die();
		if (this.human) this.human.die();
		/*
		if (this.playerNumber== "_01")
			Messenger<Vector3>.Broadcast("GOAT DIED", this.transform.position);

		if (this.playerNumber== "_02")
			Messenger<Vector3>.Broadcast("HUMAN DIED", this.transform.position);
			*/
	}

	void RestartScene() {
		
		Application.LoadLevel(Application.loadedLevel);
	}

	void stepSound() {
		;
	}

	void deadSound() {
		;
	}

}
