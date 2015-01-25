using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChivoHumanController : MonoBehaviour {
	
	public Animator anim;
	public AudioSource source;
	public AudioClip step;
	public AudioClip death;
	
	public Renderer chivoRender;
	public Renderer humanRender;
	public List<Material> chivoMaterials;
	public List<Material> humanMaterials;

	// Use this for initialization
	void Start () {
		string key= PlayerPrefs.GetString("Skin_name");
		
		if 		(key== "Skin_ChivoYRobin") 	{setChivoSkinIndex(2);setHumanSkinIndex(2);}
		else if (key== "Skin_Chivochu") 	{setChivoSkinIndex(1);setHumanSkinIndex(1);}
		else if (key== "Skin_normal") 		{setChivoSkinIndex(0);setHumanSkinIndex(0);}
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
		if (direction.x>  0) {this.goRight();}
		if (direction.x<  0) {this.goLeft();}
		if (direction.z>  0) {this.goUp();}
		if (direction.z<  0) {this.goDown();}
	}

	public void setChivoSkinIndex(int i) {
		this.chivoRender.sharedMaterial = this.chivoMaterials[i];
	}

	public void setHumanSkinIndex(int i) {
		this.humanRender.sharedMaterial = this.humanMaterials[i];
	}
}
