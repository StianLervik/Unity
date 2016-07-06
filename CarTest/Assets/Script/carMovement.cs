using UnityEngine;
using System.Collections;

public class carMovement : MonoBehaviour {
	public int maxSpeed;
	public int rotationSpeed;
	public float currentYRotation;

	private Rigidbody body;

	// Use this for initialization
	void Start () 
	{
		body = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentYRotation = transform.eulerAngles.y;
	}

	void FixedUpdate ()
	{
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		transform.Rotate (transform.rotation.z, horizontal * rotationSpeed, transform.rotation.z, Space.Self);
		Vector3 movement = transform.forward * vertical * maxSpeed;
		movement.y = body.velocity.y;
		body.velocity = movement;

	}
}
