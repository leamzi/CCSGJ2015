using UnityEngine;
using System.Collections;

public class UISceneJumper : MonoBehaviour {

	public bool homeScene;
	public bool controllerScene;

	public void GoHome(){
		Application.LoadLevel("Scene_Home");
	}

	public void GoStart(){
		Application.LoadLevel("Scene_SkinSelector");
	}

	public void GoControls(){
		Application.LoadLevel("Scene_controllers");
	}

	public void GoCredits(){
		Application.LoadLevel("Scene_credits");
	}

	public void GoControllers(){
		Application.LoadLevel("Scene_controllers");
	}

	public void GetUIKeyBoard() {
		// only in home button
		if (this.homeScene) {
			if(Input.GetButtonDown("btn_a_01") || Input.GetButtonDown("btn_a_02")) GoControllers();
		} else if (this.controllerScene)
		{
			if(Input.GetButtonDown("btn_a_01") || Input.GetButtonDown("btn_a_02")) GoStart();
		}
		else
		{
			if(Input.GetButtonDown("btn_b_01") || Input.GetButtonDown("btn_b_02")) GoHome();
		}
	}

	void Update() {
		GetUIKeyBoard();
	}
}
