using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {
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
	}
}
