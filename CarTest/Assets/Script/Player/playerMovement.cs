using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public GameObject camera01;
	public float playerSpeed;
	public float sprintModefier;
	public int jumpHeight;
	public float jumpray;

	private CapsuleCollider col;
	private Rigidbody body;
	private float scale;
	private bool crouch = false;
	private bool isJumping = false;


	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody> ();
		scale = 1.0f;
		col = GetComponent<CapsuleCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler (0, camera01.GetComponent<mouseLook> ().currentYRotation, 0);

		if (Input.GetKeyDown ("c")) {
			if (!crouch) {
				col.height = scale;
				crouch = true;
			} else {
				col.height += scale;
				crouch = false;
			}
		}
	}

	void FixedUpdate()
	{
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		float sprint = Input.GetAxis ("Sprint");

		float speed = playerSpeed + (sprintModefier * sprint);

		Vector3 movement = transform.forward * vertical;
		movement += transform.right * horizontal;
		movement.Normalize ();
		movement *= speed;
		movement.y = body.velocity.y;


		RaycastHit hit;

		if (Physics.BoxCast (transform.position, new Vector3 (0.74f, 0.9f, 0.74f), Vector3.down, out hit, transform.rotation, jumpray)) {
			if (Input.GetKey ("space") && !isJumping) {
				body.AddForce (0, jumpHeight, 0);
				isJumping = true;
			}
			isJumping = false;
		} else {
			isJumping = true;
		}

		//Animation
		/*if (horizontal != 0.0f || vertical != 0.0f) {
			camAnim.SetBool ("Moving", true);
			camAnim.speed = 1 + (sprint / 2.0f);
		} else {
			camAnim.SetBool ("Moving", false);
			camAnim.speed = 1;
		}*/
	}
}
