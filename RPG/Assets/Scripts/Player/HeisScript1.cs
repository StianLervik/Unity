using UnityEngine;
using System.Collections;

public class HeisScript1 : MonoBehaviour {

	private bool heisOpp;
	private Animator heisAnim;

	// Use this for initialization
	void Start () {
		heisAnim = GameObject.Find ("Heis").GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.collider.transform.tag == "FireBall" && heisOpp) 
		{
			heisAnim.SetBool ("Knapp", false);
			heisOpp = false;
		}
	}
}
