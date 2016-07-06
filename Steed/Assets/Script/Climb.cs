using UnityEngine;
using System.Collections;

public class Climb : MonoBehaviour {

	private PlayerMovement pM;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		string tagg = col.transform.tag;
		switch (tagg) {
		case "Player":
			pM = col.transform.gameObject.GetComponent<PlayerMovement> ();
			pM.climb = true;
			break;
		default:
			// Ingenting
			break;
		}
	}

	void OnTriggerExit(Collider col)
	{
		string tagg = col.transform.tag;
		switch (tagg) {
		case "Player":
			pM.climb = false;
			pM = null;
			break;
		default:
			// Ingenting
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
