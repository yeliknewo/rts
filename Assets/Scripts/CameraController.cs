using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
	public float zoomSpeed = 5.0f;
	public float minSize = 5.0f, maxSize = 20.0f;

	private new Camera camera
	{
		get
		{
			return GetComponent<Camera>();
		}
	}

	private PlayerController player
	{
		get
		{
			return FindObjectOfType<PlayerController>();
		}
	}

	void Update()
	{
		Cursor.lockState = CursorLockMode.Confined;
		//Cursor.visible = false;

		if (player == null)
		{
			return;
		}

		Vector2 mousePos = Input.mousePosition;
		mousePos.x = Mathf.Clamp(mousePos.x, 0, Screen.width);
		mousePos.y = Mathf.Clamp(mousePos.y, 0, Screen.height);
		Vector3 mouseInWorld = camera.ScreenToWorldPoint(mousePos);
		Vector3 playerPos = player.transform.position;
		transform.position = new Vector3((mouseInWorld.x + playerPos.x) / 2f, transform.position.y, (mouseInWorld.z + playerPos.z) / 2f);
		camera.orthographicSize = Mathf.Clamp(camera.orthographicSize - Input.GetAxis(InputManager.AXIS_MOUSE_SCROLL_WHEEL) * zoomSpeed, minSize, maxSize);
	}
}
