using UnityEngine;
using System.Collections;

public class FireBallScript : MonoBehaviour {
	public int fireSpeed;
	public float lifetime;

	private Rigidbody fireBall;
	private ParticleSystem[] pSystem;
	private Vector3 fram;
	private Vector3 dest;

	// Use this for initialization
	void Start () {
		fireBall = GetComponent<Rigidbody> ();
		pSystem = GetComponentsInChildren<ParticleSystem> ();
		fram = (dest-transform.position).normalized;
		Invoke ("Death", lifetime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate (){
		fireBall.velocity = fram * fireSpeed;
	}

	void OnCollisionEnter (Collision col)
	{
		string tagg = col.collider.transform.tag;
		if (tagg != "NoCollision") {
			Death ();
		}
	}

	public void SetDestination(Vector3 pos){
		dest = pos;
	}

	void Death(){
		foreach (ParticleSystem pS in pSystem) {
			pS.Stop ();
		}
		GetComponent<SphereCollider> ().enabled = false;
		fireSpeed = 0;
		fireBall.velocity = Vector3.zero;
		Destroy (gameObject, 2.0f);
	}
}
