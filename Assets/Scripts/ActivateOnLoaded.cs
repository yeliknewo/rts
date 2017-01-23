using UnityEngine;

public class ActivateOnLoaded : MonoBehaviour
{
	private MainController mainControl
	{
		get
		{
			return FindObjectOfType<MainController>();
		}
	}

	private void Awake()
	{
		mainControl.targets.Add(gameObject);
		gameObject.SetActive(false);
		Destroy(this);
	}
}
