using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnLoaded : MonoBehaviour
{
	public GameObject[] targets;

	private MainController mainControl
	{
		get
		{
			return FindObjectOfType<MainController>();
		}
	}

	void Update()
	{
		if(mainControl.loaded)
		{
			foreach (GameObject gameObject in targets)
			{
				gameObject.SetActive(mainControl.loaded);
			}
		}
	}
}
