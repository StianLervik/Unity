using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody body;
	private Animation anim;
	public float speed;
	public float jumpstrength = 4000.0f;
	public int jumpHeight = 8;
	public bool front = true;
	public float frontBackDist;
	public float transSpeed;
	public int rotationSpeed = 100;

	private bool isFalling = false;
	private Vector3 targetPos;
	private float backPos;
	private float frontPos;
	public bool climb = false;

	void Start()
	{
		body = GetComponent<Rigidbody> ();
		backPos = frontBackDist + transform.position.z;
		frontPos = transform.position.z;
	}

	void Update()
	{
		//Side movement
		if (Input.GetKeyDown ("w")) 
		{
			front = false;
		}

		if (Input.GetKeyDown ("s")) 
		{
			front = true;
		}

		if (front) 
		{
			targetPos = new Vector3 (transform.position.x, transform.position.y, frontPos);

		} else {
			targetPos = new Vector3 (transform.position.x, transform.position.y, backPos);
		}

		transform.position = Vector3.Lerp (transform.position, targetPos, transSpeed*Time.deltaTime);
		if (Input.GetKeyDown ("space")) 
		{
			body.velocity.y = 
		}
	}
		
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal * speed, body.velocity.y, body.velocity.z);
		body.velocity = movement;

		/*if (Input.GetKeyDown ("space") && jumpable){
			body.AddForce(Vector3.up * jumpstrength);
		}
*/
	}

}
