using UnityEngine;
using System.Collections;

public class EnemiesKilled : MonoBehaviour {
	public int totalLevelEnemies;
	public GameObject levelDoor;

	public static int enemiesKilled;

	bool  activated;

	void Awake()
	{
//		enemiesKilled = 0;
		levelDoor = GameObject.FindGameObjectWithTag ("Door");
	}

	void OnEnable()
	{
		Messenger<int>.AddListener("enemyKilled", SumEnemy);
	}
	
	void OnDisable()
	{
		Messenger<int>.RemoveListener("enemyKilled", SumEnemy);
	}
	
	void SumEnemy(int windDirection)
	{

	}

	void Update()
	{
		Debug.Log ("Enemies Killed: "+ enemiesKilled);
		if (enemiesKilled >= totalLevelEnemies) 
		{
			levelDoor.SetActive(true);
		}
	}
}
