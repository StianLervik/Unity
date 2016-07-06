using UnityEngine;
using System.Collections;

public class CAM : MonoBehaviour {
	
	public GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("ThirdPersonController");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + 2, player.transform.position.z - 8);
	}
}
