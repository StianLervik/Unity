using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
	public int fireSpeed;
	public float lifetime;

	private Rigidbody arrow;
	private Vector3 fram;
	private Vector3 dest;
	private bool point;
	private bool canFire;
	private float weapon;
	private GameObject cam;
	private Vector3 poss;
	private Quaternion rot;

	// Use this for initialization
	void Start () {
		point = true;
		weapon = GameObject.Find ("Player").GetComponent<weapon> ().prewBowStr;
		cam = GameObject.Find ("PlayerCamera");
		arrow = GetComponent<Rigidbody> ();
		fram = (dest-transform.position).normalized;
		Invoke ("Death", lifetime);
		arrow.AddForce(cam.transform.forward * fireSpeed * (weapon * 4));
	}

	// Update is called once per frame
	void Update () {
		print (poss);
	}

	void FixedUpdate (){
		if (point) {
			transform.rotation = Quaternion.LookRotation (arrow.velocity);
		} else {
			transform.position = poss;
			transform.rotation = rot;
			arrow.velocity = Vector3.zero;
		}
	}

	void OnCollisionEnter (Collision col)
	{
		string tagg = col.collider.transform.tag;
		if (tagg != "NoCollision" && tagg != "Player") {
			poss = transform.position;
			rot = transform.rotation;
			point = false;
			Death ();
		}
	}

	public void SetDestination(Vector3 pos){
		dest = pos;
	}

	void Death(){
		arrow.useGravity = false;
		GetComponent<BoxCollider> ().enabled = false;
		fireSpeed = 0;
		Destroy (gameObject, 2.0f);
	}
}
