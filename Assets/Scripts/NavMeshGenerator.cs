using RAIN.Navigation.NavMesh;
using UnityEngine;
using System.Collections;

public class NavMeshGenerator : MonoBehaviour
{
	[SerializeField]
	private bool _test = false;
	[SerializeField]
	private int _threadCount = 4;

	// This is just to test the runtime generation
	public void Update()
	{
		if (_test)
		{
			GenerateNavMesh();
			_test = false;
		}
	}

	public void GenerateNavMesh()
	{
		StartCoroutine("_GenerateNavMesh");
	}

	// This will regenerate the navigation mesh when called
	private IEnumerator _GenerateNavMesh()
	{
		CoroutineWithData cd = new CoroutineWithData(this, _Generate());
		yield return cd.coroutine;
		Object.FindObjectOfType<EnemyController>().walkSpeed = 10f;
	}

	private IEnumerator _Generate()
	{
		NavMeshRig tRig = GetComponent<NavMeshRig>();

		// Unregister any navigation mesh we may already have (probably none if you are using this)
		tRig.NavMesh.UnregisterNavigationGraph();

		tRig.NavMesh.StartCreatingContours(_threadCount);
		while (tRig.NavMesh.Creating)
		{
			tRig.NavMesh.CreateContours();

			// This could be changed to a yield (and the function to a coroutine) although as 
			// of RAIN of 2.1.4.0 (fixed since then), our navigation mesh editor has issues with it
			yield return false;
		}

		tRig.NavMesh.RegisterNavigationGraph();
		yield return true;
	}
}