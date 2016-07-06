using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {
	public GameObject player;
	public float lookSensitivity = 5f;
	public float xRotation;
	public float yRotation;
	public float currentXRotation;
	public float currentYRotation;
	public float xRotationV;
	public float yRotationV;
	public float lookSmoothDamp = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		xRotation = Input.GetAxis ("Mouse Y") * lookSensitivity;
		yRotation = Input.GetAxis ("Mouse X") * lookSensitivity;

		//currentXRotation = Mathf.SmoothDamp (currentXRotation, xRotation, ref xRotationV, lookSmoothDamp);
		//currentYRotation = Mathf.SmoothDamp (currentYRotation, yRotation, ref yRotationV, lookSmoothDamp);

		//transform.rotation = Quaternion.Euler (currentXRotation, currentYRotation + player.GetComponent<carMovement> ().currentYRotation, 0);

		Vector3 nyRot = transform.localEulerAngles;
		nyRot.y += yRotation;
		nyRot.x -= xRotation;
		if (nyRot.x >= 0.0f && nyRot.x < 180.0f) {
			nyRot.x = Mathf.Clamp (nyRot.x, 0.0f, 90.0f);
		} else {
			nyRot.x = Mathf.Clamp (nyRot.x, 270.0f, 360.0f);
		}
		transform.localEulerAngles = nyRot;

	}
}
