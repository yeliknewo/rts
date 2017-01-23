using System.Collections;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
	public GameObject treePrefab;
	public GameObject goldPrefab;
	public GameObject basePrefab;

	public Vector3 min;
	public Vector3 max;
	public float xStepsDiv;
	public float zStepsDiv;
	public int treeGenChance;
	public int goldGenChance;
	public int baseGenChance;

	private StaticNavMeshGenerator staticNavMesh
	{
		get
		{
			return Object.FindObjectOfType<StaticNavMeshGenerator>();
		}
	}

	void Start()
	{
		Generate();
	}

	private void Generate()
	{
		int width = Mathf.RoundToInt((max.x - min.x) / xStepsDiv);
		int height = Mathf.RoundToInt((max.z - min.z) / zStepsDiv);

		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				GameObject targetPrefab = null;
				if (Random.Range(0, baseGenChance) == 0)
				{
					targetPrefab = basePrefab;
				}
				else if (Random.Range(0, treeGenChance) == 0)
				{
					targetPrefab = treePrefab;
				}
				else if (Random.Range(0, goldGenChance) == 0)
				{
					targetPrefab = goldPrefab;
				}
				if (targetPrefab != null)
				{
					Instantiate(targetPrefab, new Vector3(x * xStepsDiv + min.x, 0, y * zStepsDiv + min.z), transform.rotation, transform);
				}
			}
		}

		staticNavMesh.GenerateNavMesh();
	}
}
