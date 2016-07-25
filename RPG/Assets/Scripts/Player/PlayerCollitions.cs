using UnityEngine;
using System.Collections;

public class PlayerCollitions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.transform.tag == "Lava") 
		{
			transform.position = new Vector3 (59.79f, 1.8851f, 12.52f);
		}
	}
}
