using UnityEngine;
using System.Collections;

public class EnemiesKilled : MonoBehaviour {
	public static int enemiesKilled;

	void Awake()
	{
		enemiesKilled = 0;
	}
}
