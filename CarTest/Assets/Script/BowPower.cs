using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BowPower : MonoBehaviour {
	public Scrollbar bowPower;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bowPower.size = Input.GetAxis ("Bow");
	}
}
