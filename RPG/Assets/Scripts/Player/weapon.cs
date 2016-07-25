using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {

	public GameObject fireEffect;
	public bool fire;
	public HUD hudScript;
	public GameObject statFire;
	public GameObject rArm;

	protected RaycastHit hit;
	private GameObject staticFire;

	// Use this for initialization
	void Start () {
		staticFire = GameObject.Find ("Staticfireeffect");
		GameObject.Find ("RArm").SetActive (false);
		GameObject.Find ("Staticfireeffect").SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && fire && hudScript.mana >= 10 && hudScript.spell == false) 
		{
			GameObject go = (GameObject) Instantiate (fireEffect, staticFire.transform.position, rArm.transform.rotation);
			go.GetComponent<FireBallScript> ().SetDestination (hit.point);
		}

		if (hudScript.mana > 10 && fire) {
			statFire.SetActive (true);
		} else {
			statFire.SetActive (false);
		}
	}

	void FixedUpdate ()
	{
		Physics.Raycast (GameObject.Find ("PlayerCamera").transform.position, GameObject.Find ("PlayerCamera").transform.forward, out hit);
	}
}
