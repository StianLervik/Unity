using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class M1Garand : weapon {
	public GameObject Mag;
	public GameObject TotalAmmo;

	private string clip;
	private string ammo;
	private bool m1g;

	// Use this for initialization
	void Start () {
		clip = Mag.GetComponent<InputField> ().text;
		ammo = TotalAmmo.GetComponent<InputField> ().text;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("2") || Input.GetKeyDown ("3")) 
		{
			m1g = false;
		}

	}
}
