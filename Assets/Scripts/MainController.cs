﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {
	public List<GameObject> targets = new List<GameObject>();

	private bool _loaded = false;

	public bool loaded
	{
		get
		{
			return _loaded;
		}
		private set
		{
			_loaded = value;
		}
	}

	public void GameLoaded()
	{
		loaded = true;
		foreach(GameObject target in targets)
		{
			target.SetActive(true);
		}
	}
}
