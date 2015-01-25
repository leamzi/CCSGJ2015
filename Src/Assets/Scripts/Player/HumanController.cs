using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HumanController : MonoBehaviour {
	
	public Animator anim;
	public AudioSource source;
	public AudioClip step;
	public AudioClip death;

	public Renderer render;
	public List<Material> materials;

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

	public void stepSound() {
		this.source.clip= this.step;
		this.source.Play();
	}
	
	public void deathSound() {
		this.source.clip= this.death;
		this.source.Play();
	}
	
	
	public void setDirection(Vector3 direction) {
		if (direction.x==  1) this.goRight();
		if (direction.x== -1) this.goLeft();
		if (direction.z==  1) this.goUp();
		if (direction.z== -1) this.goDown();
	}
}
