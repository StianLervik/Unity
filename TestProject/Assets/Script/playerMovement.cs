using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public GameObject camera01;
	public GameObject m1garand;
	public float playerSpeed;
	public float sprintModefier;
	private float nextFire;

	private CapsuleCollider col;
	private Rigidbody body;
	private Animator camAnim;
	private Animator fire;
	private float scale;
	private bool crouch = false;
	private bool m1g = true;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody> ();
		camAnim = camera01.GetComponent<Animator> ();
		scale = 1.0f;
		col = GetComponent<CapsuleCollider> ();
		fire = m1garand.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler (0, camera01.GetComponent<mouseLook> ().currentYRotation, 0);
		if (Input.GetButton("Fire1"))
			{
				fire.SetTrigger ("Fire");
			}
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
		body.velocity = movement;

		//Animation
		if (horizontal > 0.0f || vertical > 0.0f) {
			camAnim.SetBool ("Moving", true);
			camAnim.speed = 1 + (sprint / 2.0f);
		} else {
			camAnim.SetBool ("Moving", false);
			camAnim.speed = 1;
		}
	}
}
