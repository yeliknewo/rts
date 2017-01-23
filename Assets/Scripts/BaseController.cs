using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{

	public GameObject peasantPrefab;
	public GameObject chaserPrefab;

	public int gold = 2;

	public int peasantCost = 2;
	public int chaserCost = 4;

	public int peasantSpawnChance = 3;
	public int maxEnemyCount = 50;

	private bool spawnPeasantNext = true;

	void Update()
	{
		if(FindObjectsOfType<EnemyType>().Length < maxEnemyCount)
		{
			if (spawnPeasantNext && gold >= peasantCost)
			{
				gold -= peasantCost;
				Instantiate(peasantPrefab, transform.position, transform.rotation, transform);
				spawnPeasantNext = Random.Range(0, peasantSpawnChance) == 0;
			}
			else if (gold >= chaserCost)
			{
				gold -= chaserCost;
				Instantiate(chaserPrefab, transform.position, transform.rotation, transform);
				spawnPeasantNext = true;
			}
		}
	}

	public void AddGold(int goldAmount)
	{
		gold += goldAmount;
	}
}
