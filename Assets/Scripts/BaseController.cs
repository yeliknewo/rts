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

	public int maxEnemyCount = 50;

	public int maxPeasantCount = 5;
	public int minPeasantCount = 2;

	public float maxChaserSpawnRange = 10f;

	public float spawnCooldown = 1.0f;

	private float timer = 0.0f;

	private PlayerController _player = null;

	private PlayerController player
	{
		get
		{
			if (_player == null)
			{
				return FindObjectOfType<PlayerController>();
			}
			else
			{
				return _player;
			}
		}
	}

	void Update()
	{
		if (GetComponentsInChildren<EnemyType>().Length < maxEnemyCount && timer < Time.time)
		{
			if (ShouldSpawnPeasant() && gold >= peasantCost)
			{
				gold -= peasantCost;
				Instantiate(peasantPrefab, transform.position, transform.rotation, transform);
				timer = Time.time + spawnCooldown;
			}
			else if (ShouldSpawnChaser() && gold >= chaserCost)
			{
				gold -= chaserCost;
				Instantiate(chaserPrefab, transform.position, transform.rotation, transform);
				timer = Time.time + spawnCooldown;
			}
		}
	}

	public void AddGold(int goldAmount)
	{
		gold += goldAmount;
	}

	private bool ShouldSpawnPeasant()
	{
		return (!ShouldSpawnChaser() && GetPeasantCount() < GetMaxPeasants()) || GetPeasantCount() < GetMinPeasants();
	}

	private bool ShouldSpawnChaser()
	{
		if (player == null)
		{
			return false;
		}
		return Vector3.Distance(player.transform.position, transform.position) < GetChaserSpawnRange();
	}

	private int GetPeasantCount()
	{
		int sum = 0;
		foreach (EnemyType et in GetComponentsInChildren<EnemyType>())
		{
			if (et.enemyType == EnemyTypes.Peasant)
			{
				sum += 1;
			}
		}
		return sum;
	}

	private int GetMaxPeasants()
	{
		return maxPeasantCount;
	}

	private int GetMinPeasants()
	{
		return minPeasantCount;
	}

	private int GetChaserCount()
	{
		int sum = 0;
		foreach (EnemyType et in GetComponentsInChildren<EnemyType>())
		{
			if (et.enemyType == EnemyTypes.Chaser)
			{
				sum = +1;
			}
		}
		return sum;
	}

	private float GetChaserSpawnRange()
	{
		return maxChaserSpawnRange;
	}

	private void OnDestroy()
	{
		if (player != null)
		{
			player.RecalculateUI();
		}
		GameObject newBase = null;
		foreach (EnemyType et in FindObjectsOfType<EnemyType>())
		{
			if (et.enemyType == EnemyTypes.Base && et.gameObject != gameObject)
			{
				newBase = et.gameObject;
				break;
			}
		}
		if (newBase != null)
		{
			foreach (EnemyType et in GetComponentsInChildren<EnemyType>())
			{
				if (et.enemyType == EnemyTypes.Peasant)
				{
					Vector3 location = et.transform.position;
					Destroy(et.gameObject);
					Instantiate(chaserPrefab, location, newBase.transform.rotation, newBase.transform);
				}
				else if (et.enemyType == EnemyTypes.Chaser)
				{
					et.transform.parent = newBase.transform;
				}
			}
		}
		else
		{
			Destroy(FindObjectOfType<MapGenerator>().gameObject);
		}
	}
}
