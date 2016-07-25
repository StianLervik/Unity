using UnityEngine;
using System.Collections;

public class PlayeMovement : MonoBehaviour {
	public Rigidbody body;
	public GameObject player;
	public bool keyboard = false;
	public bool gamepad = false;
	public int playerSpeed;
	public int jumpStrength;

	private Animator playAnim;
	private bool Walking;
	private bool grounded = false;
	private bool wallJumpingleft = false;
	private bool wallJumpingright = false;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody> ();
		playAnim = player.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		print (wallJumpingleft);
		print (wallJumpingright);
	}

	void FixedUpdate (){
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		float jhorizontal = Input.GetAxis ("JHorizontal");
		float jvertical = Input.GetAxis ("JVertical");
		if (keyboard) 
		{
			Vector3 movementf = transform.forward * vertical * playerSpeed;
			Vector3 movementr = transform.right * vertical * playerSpeed;
			Vector3 movementl = -transform.forward * horizontal * playerSpeed;
			Vector3 movementd = -transform.right * horizontal * playerSpeed;
			Vector3 movement = movementf + movementr + movementl - movementd;
			movement.Normalize ();
			movement *= playerSpeed;
			movement.y = body.velocity.y;
			body.velocity = movement;

			if (body.velocity.x != 0f || body.velocity.z != 0f) 
			{
				Vector3 lVec = body.velocity.normalized;
				lVec.y = 0.0f;
				Quaternion rotation = Quaternion.LookRotation (lVec);
				player.transform.localRotation = 
					Quaternion.Slerp (player.transform.localRotation, rotation, Time.deltaTime * 8);
			}

			if ((horizontal != 0.0f || vertical != 0.0f) && grounded) {
				playAnim.SetBool ("Walking", true);
			} else {
				playAnim.SetBool ("Walking", false);
			}

			if (horizontal == 0.0f && vertical == 0.0f && grounded) {
				playAnim.SetBool("Idle", true);
			} else {
				playAnim.SetBool("Idle", false);
			}

			if (Input.GetKeyDown ("space")) 
			{
				if (wallJumpingleft) 
				{
					body.AddForce(Vector3.up * jumpStrength);
					body.AddForce(Vector3.back * jumpStrength);
					wallJumpingleft = false;
				}

				if (wallJumpingright) 
				{
					body.AddForce(Vector3.up * jumpStrength);
					body.AddForce(Vector3.forward * jumpStrength);
					wallJumpingright = false;
				}

				if (grounded) 
				{
					body.AddForce(Vector3.up * jumpStrength);
					playAnim.SetTrigger("Jump");
				}
			}
		}
	}

	void OnCollisionStay (Collision col)
	{
		if (col.collider.transform.tag == "Ground") {
			grounded = true;
		}
	}

	void OnCollisionExit (Collision col)
	{
		if (col.collider.transform.tag == "Ground") {
			grounded = false;
		}
	}

	void OnTriggerStay (Collider col)
	{
		if (col.transform.tag == "Wall" && !grounded) {
			if (col.transform.position.z > player.transform.position.z) {
				wallJumpingleft = true;
			}
				
			if (col.transform.position.z < player.transform.position.z) {
				wallJumpingright = true;
			}
		} else {
			wallJumpingleft = false;
			wallJumpingright = false;
		}
	}

	void OnTriggerExit (Collider col)
	{
		if (col.transform.tag == "Wall") 
		{
			wallJumpingleft = false;
			wallJumpingright = false;
		}
	}
}
