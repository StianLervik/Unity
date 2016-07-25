using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour {
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player1");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.transform.position.x - 5, player.transform.position.y + 6.9f,player.transform.position.z - 5);
	}
}
