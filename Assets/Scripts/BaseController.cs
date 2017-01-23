using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{

	public GameObject peasantPrefab;
	public GameObject chaserPrefab;

	public int gold = 0;

	public int peasantCost = 2;
	public int chaserCost = 4;

	private bool spawnPeasantNext = true;

	void Update()
	{
		if (spawnPeasantNext && gold >= peasantCost)
		{
			gold -= peasantCost;
			Instantiate(peasantPrefab, transform.position, transform.rotation, transform);
			spawnPeasantNext = Random.Range(0, 2) == 0;
		}
		else if (gold >= chaserCost)
		{
			gold -= chaserCost;
			Instantiate(chaserPrefab, transform.position, transform.rotation, transform);
			spawnPeasantNext = true;
		}
	}

	public void AddGold(int goldAmount)
	{
		gold += goldAmount;
	}
}
