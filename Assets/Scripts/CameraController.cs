using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform player;
	private Vector3 offset;
	public float mouseSensitivity;
	public Transform PlayerTarget;
	void Start ()
	{
		offset = transform.position - player.transform.position;
	}

	void LateUpdate ()
	{
		transform.position = player.transform.position ;

		float MouseX = Input.GetAxis ("Mouse X");
		float MouseY = Input.GetAxis ("Mouse Y");
		float rotAmountX = MouseX * mouseSensitivity;
		float rotAmountY = MouseY * mouseSensitivity;

		Vector3 targetRotationCam = transform.rotation.eulerAngles;
		Vector3 targetRotationPlayer = PlayerTarget.rotation.eulerAngles;

		targetRotationCam.x -= rotAmountY;
		targetRotationCam.y += rotAmountX;
		targetRotationPlayer.y += rotAmountX;

		transform.rotation = Quaternion.Euler (targetRotationCam);
		PlayerTarget.rotation = Quaternion.Euler (targetRotationPlayer);

	}
}
