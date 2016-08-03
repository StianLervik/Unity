using UnityEngine;
using System.Collections;

public class mouseLook : MonoBehaviour {
	public float lookSensitivity = 5f;
	public float xRotation;
	public float yRotation;
	public float currentXRotation;
	public float currentYRotation;
	public float xRotationV;
	public float yRotationV;
	public float lookSmoothDamp = 0.1f;
	public float interactDistance;
	public GameObject RArm;
	public GameObject fire;
	public HUD hudScript;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			xRotation -= Input.GetAxis ("Mouse Y") * lookSensitivity;
			yRotation += Input.GetAxis ("Mouse X") * lookSensitivity;

			xRotation = Mathf.Clamp (xRotation, -90, 90);

			currentXRotation = Mathf.SmoothDamp (currentXRotation, xRotation, ref xRotationV, lookSmoothDamp);
			currentYRotation = Mathf.SmoothDamp (currentYRotation, yRotation, ref yRotationV, lookSmoothDamp);

			transform.rotation = Quaternion.Euler (currentXRotation, currentYRotation, 0);
	}

	void FixedUpdate()
	{
		RaycastHit hit;

		if (Physics.Raycast (transform.position, transform.forward, out hit, interactDistance)) {

			if (hit.transform.tag == "StartFire" && Input.GetKeyDown ("e") && GameObject.Find ("OpeningFire").activeSelf) 
			{
				GameObject.Find ("OpeningFire").SetActive (false);
				GameObject.Find ("Player").GetComponent<weapon> ().fire = true;
				RArm.SetActive (true);
				fire.SetActive (true);
			}
				
		}
	}
}
