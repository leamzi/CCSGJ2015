using UnityEngine;
using System.Collections;

public class UISceneJumper : MonoBehaviour {

	public bool homeScene;

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

	public void GetUIKeyBoard() {
		// only in home button
		if (this.homeScene) {
			if(Input.GetButtonDown("btn_a_01")) GoStart();
		} else {
			if(Input.anyKeyDown) GoHome();
		}
	}

	void Update() {
		GetUIKeyBoard();
	}
}
