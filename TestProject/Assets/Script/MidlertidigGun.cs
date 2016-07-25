using UnityEngine;
using System.Collections;

public class MidlertidigGun : MonoBehaviour {
	public GameObject m1garand;
	public float nextFire;

	private bool canFire = true;
	private bool isFire = true;
	private bool m1g = true;
	private Animator fire;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1") && canFire)
		{
			isFire = true;
			StartCoroutine("Shoot", nextFire);
		}

		if (Input.GetButtonUp("Fire1"))
		{
			isFire = false;
		}

	}

	IEnumerator Shoot(float rate)
	{
		fire.SetTrigger ("Fire");
		canFire = false;
		yield return new WaitForSeconds (rate);
		canFire = true;
		print (canFire);
	}
}
