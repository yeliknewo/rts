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
		StartCoroutine("Generate");
	}

	private IEnumerator Generate()
	{
		int width = 500;
		int height = 500;

		bool[,] trees = new bool[width, height];

		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				trees[x, y] = Random.Range(0, 15) == 0;
				yield return null;
			}
		}

		for(int y = 0; y< height; y++)
		{
			for(int x = 0; x< width; x++)
			{
				if(trees[x,y])
				{
					Instantiate(treePrefab, new Vector3(x, 0, y), transform.rotation);
					yield return null;
				}
			}
		}

		staticNavMesh.GenerateNavMesh();
	}
}
