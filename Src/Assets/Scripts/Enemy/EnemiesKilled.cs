using UnityEngine;
using System.Collections;

public class EnemiesKilled : MonoBehaviour {
	public int totalLevelEnemies;
	public GameObject levelDoor;
	public GameObject enemyManager;

	public static int enemiesKilled;

	bool  activated;

	void Awake()
	{
//		enemiesKilled = 0;
		levelDoor = GameObject.FindGameObjectWithTag ("Door") as GameObject;
		enemyManager = GameObject.FindGameObjectWithTag ("EnemyManager") as GameObject;
	}

	void OnEnable()
	{
		Messenger<int>.AddListener("enemyKilled", SumEnemy);
	}
	
	void OnDisable()
	{
		Messenger<int>.RemoveListener("enemyKilled", SumEnemy);
	}
	
	void SumEnemy(int SumEnemy)
	{
		enemiesKilled += SumEnemy;
	}

	void Update()
	{
		Debug.Log ("Enemies Killed: "+ enemiesKilled);
		if (enemiesKilled >= totalLevelEnemies ) 
		{

			levelDoor.transform.position = new Vector3(46.82f, 3.49f, 12.9f);
			Debug.Log("Puerta Sale: "+levelDoor.transform.position.z);
			Messenger<int>.Broadcast("levelCompleted", 0);
		}
	}
}
