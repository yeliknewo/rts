using System.Collections;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
	public GameObject treePrefab;

	public Vector3 min;
	public Vector3 max;
	public float xStepsDiv;
	public float zStepsDiv;
	public int genChance;

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

		bool[,] trees = new bool[width, height];

		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				trees[x, y] = Random.Range(0, genChance) == 0;
			}
		}

		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				if (trees[x, y])
				{
					Instantiate(treePrefab, new Vector3(x * xStepsDiv + min.x, 0, y * zStepsDiv + min.z), transform.rotation, transform);
				}
			}
		}

		staticNavMesh.GenerateNavMesh();
	}
}
