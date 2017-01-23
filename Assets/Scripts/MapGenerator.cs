using System.Collections;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
	public GameObject treePrefab;

	private NavMeshGenerator staticNavMesh {
		get {
			return Object.FindObjectOfType<NavMeshGenerator>();
		}
	}

	void Start()
	{
		Generate();
	}

	private void Generate()
	{
		int div = 5;

		int width = 500 / div;
		int height = 500 / div;

		bool[,] trees = new bool[width, height];

		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				trees[x, y] = Random.Range(0, 3) == 0;
			}
		}

		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				if (trees[x, y])
				{
					Instantiate(treePrefab, new Vector3(x * div, 0, y * div), transform.rotation);
				}
			}
		}

		staticNavMesh.GenerateNavMesh();
	}
}
