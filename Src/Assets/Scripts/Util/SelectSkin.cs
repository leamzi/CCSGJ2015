using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class SelectSkin : MonoBehaviour {

	public string Selected_Skin = "Normal";
	public Image currentImage;
	public List<Sprite> skinsSprites;

	bool canChange = true;
	int i = 0;

	void Update()
	{
		float h = Input.GetAxisRaw ("Horizontal_01");

		if( h > 0 &&  i < (skinsSprites.Count - 1) && canChange)
		{
			i++;
			Debug.Log("Cambio de imagen Derecha");
			currentImage.sprite = skinsSprites[i];
			canChange = false;

		} else if (h < 0 &&  i >= 1 && canChange)
		{
			i--;
			Debug.Log("Cambio de imagen Izquierda");
			currentImage.sprite = skinsSprites[i];
			canChange = false;
		}

		if (h == 0) 
		{
			canChange = true;
		}

		switch(i)
		{
			case 0:
				Selected_Skin = "Skin_Normal";
				PlayerPrefs.SetString("Skin_name", Selected_Skin);
				Debug.Log("Skin es: "+Selected_Skin);
				break;
			case 1:
				Selected_Skin = "Skin_Chivochu";
				PlayerPrefs.SetString("Skin_name", Selected_Skin);
				Debug.Log("Skin es: "+Selected_Skin);
				break;
			case 2:
				Selected_Skin = "Skin_ChivoYRobin";
				PlayerPrefs.SetString("Skin_name", Selected_Skin);
				Debug.Log("Skin es: "+Selected_Skin);
				break;
			case 3:
				Selected_Skin = "Skin_Chivochu";
				PlayerPrefs.SetString("Skin_name", Selected_Skin);
				Debug.Log("Skin es: "+Selected_Skin);
				break;
		}

		if( Input.GetButtonDown("btn_a_01") )
		{
			Application.LoadLevel(2);
		}
	}
}
