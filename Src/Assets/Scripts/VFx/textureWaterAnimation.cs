using UnityEngine;
using System.Collections;

public class textureWaterAnimation : MonoBehaviour {
	public string textureName = "_MainTex";
	Vector2 uvOffset = Vector2.zero;
	public Vector2 uvAnimationRate = new Vector2( 0.0f, 0.1f );
	// Use this for initialization
	
	// Update is called once per frame
	void LateUpdate () {
		uvOffset += (uvAnimationRate * Time.deltaTime);
		renderer.materials[0].SetTextureOffset(textureName, uvOffset);
	}
}
