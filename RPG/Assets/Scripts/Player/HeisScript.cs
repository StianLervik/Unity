using UnityEngine;
using System.Collections;

public class HeisScript : MonoBehaviour {

	public bool heisOpp;
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
		
		if (col.collider.transform.tag == "FireBall" && !heisOpp)
		{
			heisAnim.SetBool ("Knapp", true);
			heisOpp = true;
		}

		else if (col.collider.transform.tag == "FireBall" && heisOpp) 
		{
			heisAnim.SetBool ("Knapp", false);
			heisOpp = false;
		}
	}
}
