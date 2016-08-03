using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {

	public GameObject fireEffect;
	public GameObject arrow;
	public GameObject arrowSpawner;
	public bool fire;
	public HUD hudScript;
	public GameObject statFire;
	public GameObject rArm;
	public bool bow;
	public bool magic;
	public float prewBowStr;
	public GameObject bowPower;


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
		if (Input.GetKeyDown ("mouse 0") && bow) {
			bowPower.SetActive (true);
		} 

		if (Input.GetKeyUp ("mouse 0")){
			bowPower.SetActive (false);
		}

		if (Input.GetAxis ("Bow") != 0){
			prewBowStr = Input.GetAxis ("Bow");
		}

		if (Input.GetButtonDown ("Fire1") && fire && hudScript.mana >= 10 && hudScript.spell == false && magic) 
		{
			GameObject go = (GameObject) Instantiate (fireEffect, staticFire.transform.position, rArm.transform.rotation);
			go.GetComponent<FireBallScript> ().SetDestination (hit.point);
		}

		if (Input.GetButtonUp ("Fire1") && bow) 
		{
			GameObject go = (GameObject) Instantiate (arrow, arrowSpawner.transform.position, rArm.transform.rotation);
			go.GetComponent<Arrow> ().SetDestination (hit.point);
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
