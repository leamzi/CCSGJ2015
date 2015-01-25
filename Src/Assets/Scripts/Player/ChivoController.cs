using UnityEngine;
using System.Collections;

public class ChivoController : MonoBehaviour {

	public Animator anim;

	// Use this for initialization
	void Start () {
		;
	}
	
	// Update is called once per frame
	void Update () {
		;
	}

	public void goRight() {
		this.transform.forward=  Vector3.right;
	}

	public void goLeft() {
		this.transform.forward= -Vector3.right;
	}

	public void goUp() {
		this.transform.forward= -Vector3.back;
	}

	public void goDown() {
		this.transform.forward= Vector3.back;
	}

	public void die() {
		if(this.anim) this.anim.SetTrigger("dead");
	}

	public void walk(bool moving) {
		if(this.anim) this.anim.SetBool("walk",moving);
	}


	public void setDirection(Vector3 direction) {
		if (direction.x==  1) this.goRight();
		if (direction.x== -1) this.goLeft();
		if (direction.z==  1) this.goUp();
		if (direction.z== -1) this.goDown();
	}
}
