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

	public int goldTarget;
	public int baseTarget;

	public int treeGenChance;
	public int goldGenChance;
	public int baseGenChance;

	private GameObject enemyParent;
	private GameObject treeParent;
	private GameObject goldParent;

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
		enemyParent = new GameObject();
		enemyParent.name = "EnemyParent";
		enemyParent.transform.parent = transform;

		treeParent = new GameObject();
		treeParent.name = "TreeParent";
		treeParent.transform.parent = transform;

		goldParent = new GameObject();
		goldParent.name = "GoldParent";
		goldParent.transform.parent = transform;

		int width = Mathf.RoundToInt((max.x - min.x) / xStepsDiv);
		int height = Mathf.RoundToInt((max.z - min.z) / zStepsDiv);

		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				Transform parent = transform;
				GameObject targetPrefab = null;
				if (Random.Range(0, baseGenChance) <= baseTarget)
				{
					baseTarget -= 1;
					targetPrefab = basePrefab;
					parent = enemyParent.transform;
				}
				else if (Random.Range(0, treeGenChance) == 0)
				{
					targetPrefab = treePrefab;
					parent = treeParent.transform;
				}
				else if (Random.Range(0, goldGenChance) <= goldTarget)
				{
					goldTarget -= 1;
					targetPrefab = goldPrefab;
					parent = goldParent.transform;
				}
				if (targetPrefab != null)
				{
					Instantiate(targetPrefab, new Vector3(x * xStepsDiv + min.x, 0, y * zStepsDiv + min.z), transform.rotation, parent);
				}
			}
		}

		staticNavMesh.GenerateNavMesh();
	}
}
